using AzerothCore.Utilities.ItemBuff;
using AzerothCore.Utilities.ItemBuff.Models;
using AzerothCore.Utilities.ItemBuff.Services;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace AzerothCore.Utilities.ItemBuff
{
    internal class Program
    {
        static int BUFF_MULTIPLIER = 2; // 2
        static int SPELL_BUFF_BONUS_MULTIPLIER = 1; // 2

        // 2 for T4, 3 for T5, 4 for T6
        // T4: Karazhan, Gruul's Lair, Magtheridon's Lair
        // T5: SSC, TK, Zul'Aman
        // T6: Hyjal, BT, Sunwell Plateau
        static int STAM_BUFF_BONUS_MULTIPLIER = 1; 

        static bool IS_CRAFTING_BUFF = true;

        static int CRAFTING_LEVEL_LIMIT = 70;
        
        static string INPUT_FILE_PATH = "C:\\tools\\wow\\item_buff\\input\\";
        static string OUTPUT_FILE_PATH = "C:\\tools\\wow\\item_buff\\output\\";
        
        static string CONNECTION_STRING = "server=localhost;user=root;password=root;database=acore_world;";
        static string QUERY_TEMPLATE = "SELECT * FROM item_template WHERE entry = @entry";

        static async Task Main(string[] args)
        {
            var fileService = new FileService();
            var spellLookupService = new SpellLookupService(fileService);
            var itemBuffService = new ItemBuffService(spellLookupService, BUFF_MULTIPLIER, SPELL_BUFF_BONUS_MULTIPLIER, STAM_BUFF_BONUS_MULTIPLIER, IS_CRAFTING_BUFF, CRAFTING_LEVEL_LIMIT);

            try
            {
                spellLookupService.LoadCache();

                var filesToProcess = fileService.ListFiles(INPUT_FILE_PATH);

                using (var connection = new MySqlConnection(CONNECTION_STRING))
                {
                    await connection.OpenAsync();


                    foreach (var file in filesToProcess)
                    {
                        var insertStatementsBuffed = new List<String>();
                        var insertStatementsBackup = new List<String>();

                        var itemsToProcess = fileService.LoadItems(file);

                        Console.WriteLine($"Processing file {file} with {itemsToProcess.Count} items");

                        foreach (var item in itemsToProcess)
                        {
                            Console.WriteLine($"- Processing item {item}");

                            using var command = new MySqlCommand(QUERY_TEMPLATE, connection);
                            command.Parameters.AddWithValue("@entry", item);

                            using var reader = command.ExecuteReader();

                            if (reader.Read())
                            {
                                var itemTemplate = new ItemTemplate(reader);

                                Console.WriteLine($"-- Found item '{itemTemplate.Name}'");

                                if (IS_CRAFTING_BUFF && (itemTemplate.RequiredLevel < CRAFTING_LEVEL_LIMIT || itemTemplate.Quality < (byte)ItemQuality.EPIC))
                                {
                                    Console.WriteLine($"--- Skipping crafting item '{itemTemplate.Name}' with required level '{itemTemplate.RequiredLevel}' and quality '{itemTemplate.Quality}'");
                                    continue;
                                }

                                if (itemTemplate.Class == 2 || itemTemplate.Class == 4)
                                {
                                    insertStatementsBackup.Add(itemTemplate.GenerateInsertStatement());
                                    await itemBuffService.BuffItem(itemTemplate);
                                    insertStatementsBuffed.Add(itemTemplate.GenerateInsertStatement());

                                    Console.WriteLine($"-- Buff complete for '{itemTemplate.Name}'");
                                }
                                else
                                {
                                    Console.WriteLine($"-- Skipping item '{itemTemplate.Name}' because it is not a weapon or armor (class 2 or 4). Item class is {itemTemplate.Class})");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"-- No item found in database for '{item}'");
                            }
                        }

                        spellLookupService.SaveCache();

                        var shortFileName = file.Split('\\').Last();
                        shortFileName = shortFileName.Split('.')[0] + ".sql";


                        Directory.CreateDirectory(OUTPUT_FILE_PATH + "backups");
                        Directory.CreateDirectory(OUTPUT_FILE_PATH + "buffs");
                        fileService.SaveQuery(insertStatementsBackup, OUTPUT_FILE_PATH + $"backups\\{shortFileName}");
                        fileService.SaveQuery(insertStatementsBuffed, OUTPUT_FILE_PATH + $"buffs\\{shortFileName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing item buffs");

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
