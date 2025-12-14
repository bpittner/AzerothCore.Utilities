using AzerothCore.Utilities.ItemBuff.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AzerothCore.Utilities.ItemBuff.Services
{
    public class SpellLookupService
    {
        private const string SPELL_CACHE_FILE = "C:\\Tools\\WOW\\item_buff\\_spellcache\\cache.json";
        private const string API_URL_TEMPLATE = "https://www.wowhead.com/wotlk/spell=";

        private readonly FileService _fileService;
        private Dictionary<int, SpellDetails?> _spellCache;

        public SpellLookupService(FileService fileService)
        {
            _fileService = fileService;
            _spellCache = new Dictionary<int, SpellDetails?>();
        }

        public void LoadCache()
        {
            var json = _fileService.LoadJsonFile(SPELL_CACHE_FILE);

            _spellCache = JsonConvert.DeserializeObject<Dictionary<int, SpellDetails?>>(json) ?? new Dictionary<int, SpellDetails?>();
        }

        public void SaveCache()
        {
            var json = JsonConvert.SerializeObject(_spellCache, Formatting.Indented);
            _fileService.SaveJsonFile(SPELL_CACHE_FILE, json);
        }

        public async Task<SpellDetails?> GetSpellValue(int spellId)
        {
            Console.WriteLine($"--- SpellLookupService - Processing spell '{spellId}'");
            if (_spellCache.ContainsKey(spellId))
            {
                Console.WriteLine($"--- SpellLookupService - spell '{spellId}' found in cache");

                var cachedSpell = _spellCache[spellId];

                if (cachedSpell != null && cachedSpell.Stat == StatType.UNKNOWN)
                {
                    Console.WriteLine($"--- SpellLookupService - Trying to parse unkown stat again for spell '{spellId}'");

                    cachedSpell = ParseSpellDescription(cachedSpell.Description);

                    _spellCache[spellId] = cachedSpell;
                }

                return _spellCache[spellId];
            }

            Console.WriteLine($"--- SpellLookupService - spell '{spellId}' not in cache - retrieving from API");


            SpellDetails? spell = null;

            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(API_URL_TEMPLATE + spellId);

                var htmlContent = await result.Content.ReadAsStringAsync();
                Thread.Sleep(2000); // Added sleep to not overload API

                var doc = new HtmlDocument();
                doc.LoadHtml(htmlContent);

                var metaDescription = doc.DocumentNode.SelectSingleNode("//meta[@name='description']");

                if (metaDescription != null)
                {
                    string description = metaDescription.GetAttributeValue("content", "");

                    spell = ParseSpellDescription(description);
                }
                else
                {
                    Console.WriteLine("--- SpellLookupService - No description from API for '{spellId}' - Returning null");
                }
            }
            if (spell != null && spell.Stat == StatType.UNKNOWN)
            {
                Console.WriteLine($"--- SpellLookupService - Unable to parse spell details for '{spellId}' with description '{spell.Description}'");
            }

            _spellCache[spellId] = spell;

            return spell;
        }

        private SpellDetails ParseSpellDescription(string description)
        {
            var cleanDescription = description.Contains(".") ? description.Split('.')[0] : description;

            var spell = new SpellDetails();
            spell.Stat = StatType.UNKNOWN;

            spell.Description = cleanDescription;

            var desc = spell.Description.ToLower();


            // Conditional Parsing logic
            if (desc.Contains("spell power"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.SPELL_POWER;
            }
            else if (desc.Contains("spell penetration"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.SPELL_PENETRATION;
            }
            else if (desc.Contains("restores") && desc.Contains("mana"))
            {
                int value = ParseSpellValue(description, true);

                spell.Value = value;
                spell.Stat = StatType.MANA_REGENERATION;
            }
            else if (desc.Contains("attack power"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.ATTACK_POWER;
            }
            else if (desc.Contains("critical strike rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.CRIT_RATING;
            }
            else if (desc.Contains("hit rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.HIT_RATING;
            }
            else if (desc.Contains("expertise"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.EXPERTISE_RATING;
            }
            else if (desc.Contains("defense rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.DEFENSE_SKILL_RATING;
            }
            else if (desc.Contains("block value"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.BLOCK_VALUE;
            }
            else if (desc.Contains("block rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.BLOCK_RATING;
            }
            else if (desc.Contains("dodge rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.DODGE_RATING;
            }
            else if (desc.Contains("parry rating"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.PARRY_RATING;
            }
            else if (desc.Contains("armor penetration"))
            {
                int value = ParseSpellValue(description, false);

                spell.Value = value;
                spell.Stat = StatType.ARMOR_PENETRATION_RATING;
            }
            else if (desc.Contains("pet"))
            {
                spell.Stat = StatType.IGNORE;
            }
            else if (desc.Contains("stealth"))
            {
                spell.Stat = StatType.IGNORE;
            }

            return spell;
        }

        private int ParseSpellValue(string description, bool isManaRegen)
        {
            string stringVal;

            try
            {

                if (description.Contains("."))
                {
                    description = description.Split(".")[0];
                }

                if (isManaRegen)
                {
                    stringVal = description.Split(' ')[1];
                }
                else
                {
                    stringVal = description.Split(' ').Last();
                }

                int intVal;


                Console.WriteLine($"--- SpellLookupService - attempting to parse {stringVal} out of {description}");
                if (Int32.TryParse(stringVal, out intVal))
                {
                    return intVal;
                }
                else
                {
                    Console.WriteLine($"--- SpellLookupService - failed parsing value from string '{description}'");
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--- SpellLookupService - critical parse failure! input was '{description}' and '{isManaRegen}' with excetion '{ex.Message}'");
                return 0;
            }
        }
    }
}
