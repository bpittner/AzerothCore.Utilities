using MySql.Data.MySqlClient;
using System.Reflection;

namespace AzerothCore.Utilities.ItemBuff.Models
{
    public class ItemTemplate
    {
        [ColumnName("entry")] public int Entry { get; set; }
        [ColumnName("class")] public byte Class { get; set; }
        [ColumnName("subclass")] public byte Subclass { get; set; }
        [ColumnName("SoundOverrideSubclass")] public sbyte SoundOverrideSubclass { get; set; }
        [ColumnName("name")] public string Name { get; set; }
        [ColumnName("displayid")] public uint DisplayId { get; set; }
        [ColumnName("Quality")] public byte Quality { get; set; }
        [ColumnName("Flags")] public uint Flags { get; set; }
        [ColumnName("FlagsExtra")] public uint FlagsExtra { get; set; }
        [ColumnName("BuyCount")] public byte BuyCount { get; set; }
        [ColumnName("BuyPrice")] public long BuyPrice { get; set; }
        [ColumnName("SellPrice")] public uint SellPrice { get; set; }
        [ColumnName("InventoryType")] public byte InventoryType { get; set; }
        [ColumnName("AllowableClass")] public int AllowableClass { get; set; }
        [ColumnName("AllowableRace")] public int AllowableRace { get; set; }
        [ColumnName("ItemLevel")] public ushort ItemLevel { get; set; }
        [ColumnName("RequiredLevel")] public byte RequiredLevel { get; set; }
        [ColumnName("RequiredSkill")] public short RequiredSkill { get; set; }
        [ColumnName("RequiredSkillRank")] public short RequiredSkillRank { get; set; }
        [ColumnName("requiredspell")] public uint RequiredSpell { get; set; }
        [ColumnName("requiredhonorrank")] public uint RequiredHonorRank { get; set; }
        [ColumnName("RequiredCityRank")] public uint RequiredCityRank { get; set; }
        [ColumnName("RequiredReputationFaction")] public ushort RequiredReputationFaction { get; set; }
        [ColumnName("RequiredReputationRank")] public ushort RequiredReputationRank { get; set; }
        [ColumnName("maxcount")] public int MaxCount { get; set; }
        [ColumnName("stackable")] public int Stackable { get; set; }
        [ColumnName("ContainerSlots")] public byte ContainerSlots { get; set; }
//        [ColumnName("StatsCount")] public byte StatsCount { get; set; }

        [ColumnName("stat_type1")] public byte StatType1 { get; set; }
        [ColumnName("stat_value1")] public int StatValue1 { get; set; }
        [ColumnName("stat_type2")] public byte StatType2 { get; set; }
        [ColumnName("stat_value2")] public int StatValue2 { get; set; }
        [ColumnName("stat_type3")] public byte StatType3 { get; set; }
        [ColumnName("stat_value3")] public int StatValue3 { get; set; }
        [ColumnName("stat_type4")] public byte StatType4 { get; set; }
        [ColumnName("stat_value4")] public int StatValue4 { get; set; }
        [ColumnName("stat_type5")] public byte StatType5 { get; set; }
        [ColumnName("stat_value5")] public int StatValue5 { get; set; }
        [ColumnName("stat_type6")] public byte StatType6 { get; set; }
        [ColumnName("stat_value6")] public int StatValue6 { get; set; }
        [ColumnName("stat_type7")] public byte StatType7 { get; set; }
        [ColumnName("stat_value7")] public int StatValue7 { get; set; }
        [ColumnName("stat_type8")] public byte StatType8 { get; set; }
        [ColumnName("stat_value8")] public int StatValue8 { get; set; }
        [ColumnName("stat_type9")] public byte StatType9 { get; set; }
        [ColumnName("stat_value9")] public int StatValue9 { get; set; }
        [ColumnName("stat_type10")] public byte StatType10 { get; set; }
        [ColumnName("stat_value10")] public int StatValue10 { get; set; }

        [ColumnName("ScalingStatDistribution")] public short ScalingStatDistribution { get; set; }
        [ColumnName("ScalingStatValue")] public uint ScalingStatValue { get; set; }

        [ColumnName("dmg_min1")] public float DmgMin1 { get; set; }
        [ColumnName("dmg_max1")] public float DmgMax1 { get; set; }
        [ColumnName("dmg_type1")] public byte DmgType1 { get; set; }
        [ColumnName("dmg_min2")] public float DmgMin2 { get; set; }
        [ColumnName("dmg_max2")] public float DmgMax2 { get; set; }
        [ColumnName("dmg_type2")] public byte DmgType2 { get; set; }

        [ColumnName("armor")] public uint Armor { get; set; }
        [ColumnName("holy_res")] public short HolyRes { get; set; }
        [ColumnName("fire_res")] public short FireRes { get; set; }
        [ColumnName("nature_res")] public short NatureRes { get; set; }
        [ColumnName("frost_res")] public short FrostRes { get; set; }
        [ColumnName("shadow_res")] public short ShadowRes { get; set; }
        [ColumnName("arcane_res")] public short ArcaneRes { get; set; }

        [ColumnName("delay")] public ushort Delay { get; set; }
        [ColumnName("ammo_type")] public byte AmmoType { get; set; }
        [ColumnName("RangedModRange")] public float RangedModRange { get; set; }

        [ColumnName("spellid_1")] public int SpellId1 { get; set; }
        [ColumnName("spelltrigger_1")] public byte SpellTrigger1 { get; set; }
        [ColumnName("spellcharges_1")] public short SpellCharges1 { get; set; }
        [ColumnName("spellppmRate_1")] public float SpellPpmRate1 { get; set; }
        [ColumnName("spellcooldown_1")] public int SpellCooldown1 { get; set; }
        [ColumnName("spellcategory_1")] public ushort SpellCategory1 { get; set; }
        [ColumnName("spellcategorycooldown_1")] public int SpellCategoryCooldown1 { get; set; }

        [ColumnName("spellid_2")] public int SpellId2 { get; set; }
        [ColumnName("spelltrigger_2")] public byte SpellTrigger2 { get; set; }
        [ColumnName("spellcharges_2")] public short SpellCharges2 { get; set; }
        [ColumnName("spellppmRate_2")] public float SpellPpmRate2 { get; set; }
        [ColumnName("spellcooldown_2")] public int SpellCooldown2 { get; set; }
        [ColumnName("spellcategory_2")] public ushort SpellCategory2 { get; set; }
        [ColumnName("spellcategorycooldown_2")] public int SpellCategoryCooldown2 { get; set; }

        [ColumnName("spellid_3")] public int SpellId3 { get; set; }
        [ColumnName("spelltrigger_3")] public byte SpellTrigger3 { get; set; }
        [ColumnName("spellcharges_3")] public short SpellCharges3 { get; set; }
        [ColumnName("spellppmRate_3")] public float SpellPpmRate3 { get; set; }
        [ColumnName("spellcooldown_3")] public int SpellCooldown3 { get; set; }
        [ColumnName("spellcategory_3")] public ushort SpellCategory3 { get; set; }
        [ColumnName("spellcategorycooldown_3")] public int SpellCategoryCooldown3 { get; set; }

        [ColumnName("spellid_4")] public int SpellId4 { get; set; }
        [ColumnName("spelltrigger_4")] public byte SpellTrigger4 { get; set; }
        [ColumnName("spellcharges_4")] public short SpellCharges4 { get; set; }
        [ColumnName("spellppmRate_4")] public float SpellPpmRate4 { get; set; }
        [ColumnName("spellcooldown_4")] public int SpellCooldown4 { get; set; }
        [ColumnName("spellcategory_4")] public ushort SpellCategory4 { get; set; }
        [ColumnName("spellcategorycooldown_4")] public int SpellCategoryCooldown4 { get; set; }

        [ColumnName("spellid_5")] public int SpellId5 { get; set; }
        [ColumnName("spelltrigger_5")] public byte SpellTrigger5 { get; set; }
        [ColumnName("spellcharges_5")] public short SpellCharges5 { get; set; }
        [ColumnName("spellppmRate_5")] public float SpellPpmRate5 { get; set; }
        [ColumnName("spellcooldown_5")] public int SpellCooldown5 { get; set; }
        [ColumnName("spellcategory_5")] public ushort SpellCategory5 { get; set; }
        [ColumnName("spellcategorycooldown_5")] public int SpellCategoryCooldown5 { get; set; }

        [ColumnName("bonding")] public byte Bonding { get; set; }
        [ColumnName("description")] public string Description { get; set; }
        [ColumnName("PageText")] public uint PageText { get; set; }
        [ColumnName("LanguageID")] public byte LanguageID { get; set; }
        [ColumnName("PageMaterial")] public byte PageMaterial { get; set; }
        [ColumnName("startquest")] public uint StartQuest { get; set; }
        [ColumnName("lockid")] public uint LockId { get; set; }
        [ColumnName("Material")] public sbyte Material { get; set; }
        [ColumnName("sheath")] public byte Sheath { get; set; }
        [ColumnName("RandomProperty")] public int RandomProperty { get; set; }
        [ColumnName("RandomSuffix")] public uint RandomSuffix { get; set; }
        [ColumnName("block")] public uint Block { get; set; }
        [ColumnName("itemset")] public int ItemSet { get; set; }
        [ColumnName("MaxDurability")] public ushort MaxDurability { get; set; }
        [ColumnName("area")] public int Area { get; set; }
        [ColumnName("Map")] public short Map { get; set; }
        [ColumnName("BagFamily")] public int BagFamily { get; set; }
        [ColumnName("TotemCategory")] public int TotemCategory { get; set; }

        [ColumnName("socketColor_1")] public byte SocketColor1 { get; set; }
        [ColumnName("socketContent_1")] public int SocketContent1 { get; set; }
        [ColumnName("socketColor_2")] public byte SocketColor2 { get; set; }
        [ColumnName("socketContent_2")] public int SocketContent2 { get; set; }
        [ColumnName("socketColor_3")] public byte SocketColor3 { get; set; }
        [ColumnName("socketContent_3")] public int SocketContent3 { get; set; }

        [ColumnName("socketBonus")] public int SocketBonus { get; set; }
        [ColumnName("GemProperties")] public int GemProperties { get; set; }
        [ColumnName("RequiredDisenchantSkill")] public short RequiredDisenchantSkill { get; set; }
        [ColumnName("ArmorDamageModifier")] public float ArmorDamageModifier { get; set; }
        [ColumnName("duration")] public uint Duration { get; set; }
        [ColumnName("ItemLimitCategory")] public short ItemLimitCategory { get; set; }
        [ColumnName("HolidayId")] public uint HolidayId { get; set; }
        [ColumnName("ScriptName")] public string ScriptName { get; set; }
        [ColumnName("DisenchantID")] public uint DisenchantID { get; set; }
        [ColumnName("FoodType")] public byte FoodType { get; set; }
        [ColumnName("minMoneyLoot")] public uint MinMoneyLoot { get; set; }
        [ColumnName("maxMoneyLoot")] public uint MaxMoneyLoot { get; set; }
        [ColumnName("flagsCustom")] public uint FlagsCustom { get; set; }
        [ColumnName("VerifiedBuild")] public int VerifiedBuild { get; set; }

        public ItemTemplate(MySqlDataReader reader)
        {
            Entry = reader.GetInt32("entry");
            Class = reader.GetByte("class");
            Subclass = reader.GetByte("subclass");
            SoundOverrideSubclass = reader.GetSByte("SoundOverrideSubclass");
            Name = reader.GetString("name");
            DisplayId = (uint)reader.GetInt32("displayid");
            Quality = reader.GetByte("Quality");
            Flags = (uint)reader.GetInt32("Flags");
            FlagsExtra = (uint)reader.GetInt32("FlagsExtra");
            BuyCount = reader.GetByte("BuyCount");
            BuyPrice = reader.GetInt64("BuyPrice");
            SellPrice = (uint)reader.GetInt32("SellPrice");
            InventoryType = reader.GetByte("InventoryType");
            AllowableClass = reader.GetInt32("AllowableClass");
            AllowableRace = reader.GetInt32("AllowableRace");
            ItemLevel = reader.GetUInt16("ItemLevel");
            RequiredLevel = reader.GetByte("RequiredLevel");
            RequiredSkill = reader.GetInt16("RequiredSkill");
            RequiredSkillRank = reader.GetInt16("RequiredSkillRank");
            RequiredSpell = (uint)reader.GetInt32("requiredspell");
            RequiredHonorRank = (uint)reader.GetInt32("requiredhonorrank");
            RequiredCityRank = (uint)reader.GetInt32("RequiredCityRank");
            RequiredReputationFaction = reader.GetUInt16("RequiredReputationFaction");
            RequiredReputationRank = reader.GetUInt16("RequiredReputationRank");
            MaxCount = reader.GetInt32("maxcount");
            Stackable = reader.GetInt32("stackable");
            ContainerSlots = reader.GetByte("ContainerSlots");
//            StatsCount = reader.GetByte("StatsCount");

            StatType1 = reader.GetByte("stat_type1");
            StatValue1 = reader.GetInt32("stat_value1");
            StatType2 = reader.GetByte("stat_type2");
            StatValue2 = reader.GetInt32("stat_value2");
            StatType3 = reader.GetByte("stat_type3");
            StatValue3 = reader.GetInt32("stat_value3");
            StatType4 = reader.GetByte("stat_type4");
            StatValue4 = reader.GetInt32("stat_value4");
            StatType5 = reader.GetByte("stat_type5");
            StatValue5 = reader.GetInt32("stat_value5");
            StatType6 = reader.GetByte("stat_type6");
            StatValue6 = reader.GetInt32("stat_value6");
            StatType7 = reader.GetByte("stat_type7");
            StatValue7 = reader.GetInt32("stat_value7");
            StatType8 = reader.GetByte("stat_type8");
            StatValue8 = reader.GetInt32("stat_value8");
            StatType9 = reader.GetByte("stat_type9");
            StatValue9 = reader.GetInt32("stat_value9");
            StatType10 = reader.GetByte("stat_type10");
            StatValue10 = reader.GetInt32("stat_value10");

            ScalingStatDistribution = reader.GetInt16("ScalingStatDistribution");
            ScalingStatValue = (uint)reader.GetInt32("ScalingStatValue");

            DmgMin1 = reader.GetFloat("dmg_min1");
            DmgMax1 = reader.GetFloat("dmg_max1");
            DmgType1 = reader.GetByte("dmg_type1");
            DmgMin2 = reader.GetFloat("dmg_min2");
            DmgMax2 = reader.GetFloat("dmg_max2");
            DmgType2 = reader.GetByte("dmg_type2");

            Armor = (uint)reader.GetInt32("armor");
            HolyRes = reader.GetInt16("holy_res");
            FireRes = reader.GetInt16("fire_res");
            NatureRes = reader.GetInt16("nature_res");
            FrostRes = reader.GetInt16("frost_res");
            ShadowRes = reader.GetInt16("shadow_res");
            ArcaneRes = reader.GetInt16("arcane_res");

            Delay = reader.GetUInt16("delay");
            AmmoType = reader.GetByte("ammo_type");
            RangedModRange = reader.GetFloat("RangedModRange");

            SpellId1 = reader.GetInt32("spellid_1");
            SpellTrigger1 = reader.GetByte("spelltrigger_1");
            SpellCharges1 = reader.GetInt16("spellcharges_1");
            SpellPpmRate1 = reader.GetFloat("spellppmRate_1");
            SpellCooldown1 = reader.GetInt32("spellcooldown_1");
            SpellCategory1 = reader.GetUInt16("spellcategory_1");
            SpellCategoryCooldown1 = reader.GetInt32("spellcategorycooldown_1");

            SpellId2 = reader.GetInt32("spellid_2");
            SpellTrigger2 = reader.GetByte("spelltrigger_2");
            SpellCharges2 = reader.GetInt16("spellcharges_2");
            SpellPpmRate2 = reader.GetFloat("spellppmRate_2");
            SpellCooldown2 = reader.GetInt32("spellcooldown_2");
            SpellCategory2 = reader.GetUInt16("spellcategory_2");
            SpellCategoryCooldown2 = reader.GetInt32("spellcategorycooldown_2");

            SpellId3 = reader.GetInt32("spellid_3");
            SpellTrigger3 = reader.GetByte("spelltrigger_3");
            SpellCharges3 = reader.GetInt16("spellcharges_3");
            SpellPpmRate3 = reader.GetFloat("spellppmRate_3");
            SpellCooldown3 = reader.GetInt32("spellcooldown_3");
            SpellCategory3 = reader.GetUInt16("spellcategory_3");
            SpellCategoryCooldown3 = reader.GetInt32("spellcategorycooldown_3");

            SpellId4 = reader.GetInt32("spellid_4");
            SpellTrigger4 = reader.GetByte("spelltrigger_4");
            SpellCharges4 = reader.GetInt16("spellcharges_4");
            SpellPpmRate4 = reader.GetFloat("spellppmRate_4");
            SpellCooldown4 = reader.GetInt32("spellcooldown_4");
            SpellCategory4 = reader.GetUInt16("spellcategory_4");
            SpellCategoryCooldown4 = reader.GetInt32("spellcategorycooldown_4");

            SpellId5 = reader.GetInt32("spellid_5");
            SpellTrigger5 = reader.GetByte("spelltrigger_5");
            SpellCharges5 = reader.GetInt16("spellcharges_5");
            SpellPpmRate5 = reader.GetFloat("spellppmRate_5");
            SpellCooldown5 = reader.GetInt32("spellcooldown_5");
            SpellCategory5 = reader.GetUInt16("spellcategory_5");
            SpellCategoryCooldown5 = reader.GetInt32("spellcategorycooldown_5");

            Bonding = reader.GetByte("bonding");
            Description = reader.GetString("description");
            PageText = (uint)reader.GetInt32("PageText");
            LanguageID = reader.GetByte("LanguageID");
            PageMaterial = reader.GetByte("PageMaterial");
            StartQuest = (uint)reader.GetInt32("startquest");
            LockId = (uint)reader.GetInt32("lockid");
            Material = reader.GetSByte("Material");
            Sheath = reader.GetByte("sheath");
            RandomProperty = reader.GetInt32("RandomProperty");
            RandomSuffix = (uint)reader.GetInt32("RandomSuffix");
            Block = (uint)reader.GetInt32("block");
            ItemSet = reader.GetInt32("itemset");
            MaxDurability = reader.GetUInt16("MaxDurability");
            Area = reader.GetInt32("area");
            Map = reader.GetInt16("Map");
            BagFamily = reader.GetInt32("BagFamily");
            TotemCategory = reader.GetInt32("TotemCategory");

            SocketColor1 = reader.GetByte("socketColor_1");
            SocketContent1 = reader.GetInt32("socketContent_1");
            SocketColor2 = reader.GetByte("socketColor_2");
            SocketContent2 = reader.GetInt32("socketContent_2");
            SocketColor3 = reader.GetByte("socketColor_3");
            SocketContent3 = reader.GetInt32("socketContent_3");

            SocketBonus = reader.GetInt32("socketBonus");
            GemProperties = reader.GetInt32("GemProperties");
            RequiredDisenchantSkill = reader.GetInt16("RequiredDisenchantSkill");
            ArmorDamageModifier = reader.GetFloat("ArmorDamageModifier");
            Duration = (uint)reader.GetInt32("duration");
            ItemLimitCategory = reader.GetInt16("ItemLimitCategory");
            HolidayId = (uint)reader.GetInt32("HolidayId");
            ScriptName = reader.GetString("ScriptName");
            DisenchantID = (uint)reader.GetInt32("DisenchantID");
            FoodType = reader.GetByte("FoodType");
            MinMoneyLoot = (uint)reader.GetInt32("minMoneyLoot");
            MaxMoneyLoot = (uint)reader.GetInt32("maxMoneyLoot");
            FlagsCustom = (uint)reader.GetInt32("flagsCustom");
            VerifiedBuild = reader.GetInt32("VerifiedBuild");
        }

        public List<byte> GetStatTypesAsList()
        {
            return new List<byte>()
            {
                StatType1, StatType2, StatType3, StatType4, StatType5, StatType6, StatType7, StatType8, StatType9, StatType10
            };
        }

        public List<int> GetStatValuesAsList()
        {
            return new List<int>()
            {
                StatValue1, StatValue2, StatValue3, StatValue4, StatValue5, StatValue6, StatValue7, StatValue8, StatValue9, StatValue10
            };
        }

        public void SetStatsFromList(List<byte> statTypes, List<int> statValues)
        {
            StatType1 = statTypes[0];
            StatType2 = statTypes[1];
            StatType3 = statTypes[2];
            StatType4 = statTypes[3];
            StatType5 = statTypes[4];
            StatType6 = statTypes[5];
            StatType7 = statTypes[6];
            StatType8 = statTypes[7];
            StatType9 = statTypes[8];
            StatType10 = statTypes[9];

            StatValue1 = statValues[0];
            StatValue2 = statValues[1];
            StatValue3 = statValues[2];
            StatValue4 = statValues[3];
            StatValue5 = statValues[4];
            StatValue6 = statValues[5];
            StatValue7 = statValues[6];
            StatValue8 = statValues[7];
            StatValue9 = statValues[8];
            StatValue10 = statValues[9];
        }

        public string GenerateInsertStatement()
        {
            var type = typeof(ItemTemplate);
            var properties = type.GetProperties();

            var columnNames = new List<string>();
            var values = new List<string>();

            foreach (var prop in properties)
            {
                var attr = prop.GetCustomAttribute<ColumnNameAttribute>();
                string columnName = attr?.Name ?? prop.Name;

                columnNames.Add(columnName);

                var value = prop.GetValue(this);
                if (value == null)
                {
                    values.Add("NULL");
                }
                else if (prop.PropertyType == typeof(string))
                {
                    values.Add($"'{MySqlHelper.EscapeString(value.ToString())}'");
                }
                else if (prop.PropertyType == typeof(bool))
                {
                    values.Add((bool)value ? "1" : "0");
                }
                else if (prop.PropertyType == typeof(float) || prop.PropertyType == typeof(double))
                {
                    values.Add(Convert.ToString(value, System.Globalization.CultureInfo.InvariantCulture));
                }
                else
                {
                    values.Add(value.ToString() ?? "null");
                }
            }

            string dropStatement = $"DELETE FROM `item_template` WHERE (`entry` = {this.Entry});\r\n";
            string insertStatement = $"INSERT INTO `item_template` (`{string.Join("`, `", columnNames)}`) \r\n  VALUES ({string.Join(", ", values)});\r\n\r\n";

            return dropStatement + insertStatement;
        }
    }
}
