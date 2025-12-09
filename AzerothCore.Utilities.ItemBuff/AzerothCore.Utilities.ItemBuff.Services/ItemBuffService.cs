using AzerothCore.Utilities.ItemBuff.Models;
using MySqlX.XDevAPI.CRUD;
using System.Runtime.InteropServices;

namespace AzerothCore.Utilities.ItemBuff.Services
{
    public class ItemBuffService
    {
        private readonly SpellLookupService _spellLookupService;
        private readonly int _multiplier;
        private readonly int _spell_bonus_multiplier;
        private readonly int _stam_bonus_multiplier;

        public ItemBuffService(SpellLookupService spellLookupService, int multipler, int spell_bonus_multiplier, int stam_bonus_multiplier)
        {
            _spellLookupService = spellLookupService;
            _multiplier = multipler;
            _spell_bonus_multiplier = spell_bonus_multiplier;
            _stam_bonus_multiplier = stam_bonus_multiplier;
        }

        public async Task BuffItem(ItemTemplate item)
        {

            if (item.SpellId1 != 0)
            {
                var spellDetails = await _spellLookupService.GetSpellValue(item.SpellId1);

                if (ShouldAddSpellAsStat(spellDetails))
                {
                    AddStat(item, spellDetails);
                    item.SpellId1 = 0;
                    item.SpellTrigger1 = 0;
                }
            }

            if (item.SpellId2 != 0)
            {
                var spellDetails = await _spellLookupService.GetSpellValue(item.SpellId2);

                if (ShouldAddSpellAsStat(spellDetails))
                {
                    AddStat(item, spellDetails);
                    item.SpellId2 = 0;
                    item.SpellTrigger2 = 0;
                }
            }

            if (item.SpellId3 != 0)
            {
                var spellDetails = await _spellLookupService.GetSpellValue(item.SpellId3);

                if (ShouldAddSpellAsStat(spellDetails))
                {
                    AddStat(item, spellDetails);
                    item.SpellId3 = 0;
                    item.SpellTrigger3 = 0;
                }
            }

            if (item.SpellId4 != 0)
            {
                var spellDetails = await _spellLookupService.GetSpellValue(item.SpellId4);

                if (ShouldAddSpellAsStat(spellDetails))
                {
                    AddStat(item, spellDetails);
                    item.SpellId4 = 0;
                    item.SpellTrigger4 = 0;
                }
            }

            if (item.SpellId5 != 0)
            {
                var spellDetails = await _spellLookupService.GetSpellValue(item.SpellId5);

                if (ShouldAddSpellAsStat(spellDetails))
                {
                    AddStat(item, spellDetails);
                    item.SpellId5 = 0;
                    item.SpellTrigger5 = 0;
                }
            }

            if (item.Name.ToLower().Contains("wildheart")
                || item.Name.ToLower().Contains("feralheart")
                || item.Name.ToLower().Contains("cenarion")
                || item.Name.ToLower().Contains("stormrage")
                || item.Name.ToLower().Contains("dreamwalker"))
            {
                AddDruidStats(item);
            }

            if (item.Name.ToLower().Contains("lawbringer")
                || item.Name.ToLower().Contains("judgement")
                || item.Name.ToLower().Contains("redemption"))
            {
                AddPaladinStats(item);
            }

            BuffStats(item);
        }

        private void AddDruidStats(ItemTemplate item)
        {
            int max = 0;

            if(item.StatValue1 > max && item.StatType1 != (byte)StatType.SPELL_POWER) {  max = item.StatValue1; }
            if(item.StatValue2 > max && item.StatType2 != (byte)StatType.SPELL_POWER) { max = item.StatValue2; }
            if(item.StatValue3 > max && item.StatType3 != (byte)StatType.SPELL_POWER) { max = item.StatValue3; }
            if(item.StatValue4 > max && item.StatType4 != (byte)StatType.SPELL_POWER) { max = item.StatValue4; }
            if(item.StatValue5 > max && item.StatType5 != (byte)StatType.SPELL_POWER) { max = item.StatValue5; }
            if(item.StatValue6 > max && item.StatType6 != (byte)StatType.SPELL_POWER) { max = item.StatValue6; }
            if(item.StatValue7 > max && item.StatType7 != (byte)StatType.SPELL_POWER) { max = item.StatValue7; }
            if(item.StatValue8 > max && item.StatType8 != (byte)StatType.SPELL_POWER) { max = item.StatValue8; }
            if(item.StatValue9 > max && item.StatType9 != (byte)StatType.SPELL_POWER) { max = item.StatValue9; }
            if(item.StatValue10 > max && item.StatType10 != (byte)StatType.SPELL_POWER) { max = item.StatValue10; }

            var agil = new SpellDetails { Stat = StatType.AGILITY, Value = max };
            var str = new SpellDetails { Stat = StatType.STRENGHT, Value = max };

            if(!HasStat(item, StatType.AGILITY))
            {
                AddStat(item, agil);
            }

            if (!HasStat(item, StatType.STRENGHT))
            {
                AddStat(item, str);
            }

            if (item.InventoryType == (byte)ItemSlot.HEAD)
            {
                if(!HasStat(item, StatType.CRIT_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.CRIT_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.HANDS)
            {
                if (!HasStat(item, StatType.HIT_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.HIT_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.WRISTS)
            {
                if (!HasStat(item, StatType.HASTE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.HASTE_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.WAIST)
            {
                if (!HasStat(item, StatType.ARMOR_PENETRATION_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.ARMOR_PENETRATION_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.LEGS)
            {
                if (!HasStat(item, StatType.DODGE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.DODGE_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.SHOULDERS)
            {
                if (!HasStat(item, StatType.EXPERTISE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.EXPERTISE_RATING, Value = max / 2 });
            }
            
            if (item.InventoryType == (byte)ItemSlot.CHEST)
            {
                if (!HasStat(item, StatType.DEFENSE_SKILL_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.DEFENSE_SKILL_RATING, Value = max / 2 });
            }
            
            if (item.InventoryType == (byte)ItemSlot.FEET)
            {
                if (!HasStat(item, StatType.HASTE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.HASTE_RATING, Value = max / 2 });
            }

            ConsolidateStat(item, StatType.STRENGHT);
            ConsolidateStat(item, StatType.AGILITY);
        }

        private void AddPaladinStats(ItemTemplate item)
        {
            int max = 0;

            if (item.StatValue1 > max && item.StatType1 != (byte)StatType.SPELL_POWER) { max = item.StatValue1; }
            if (item.StatValue2 > max && item.StatType2 != (byte)StatType.SPELL_POWER) { max = item.StatValue2; }
            if (item.StatValue3 > max && item.StatType3 != (byte)StatType.SPELL_POWER) { max = item.StatValue3; }
            if (item.StatValue4 > max && item.StatType4 != (byte)StatType.SPELL_POWER) { max = item.StatValue4; }
            if (item.StatValue5 > max && item.StatType5 != (byte)StatType.SPELL_POWER) { max = item.StatValue5; }
            if (item.StatValue6 > max && item.StatType6 != (byte)StatType.SPELL_POWER) { max = item.StatValue6; }
            if (item.StatValue7 > max && item.StatType7 != (byte)StatType.SPELL_POWER) { max = item.StatValue7; }
            if (item.StatValue8 > max && item.StatType8 != (byte)StatType.SPELL_POWER) { max = item.StatValue8; }
            if (item.StatValue9 > max && item.StatType9 != (byte)StatType.SPELL_POWER) { max = item.StatValue9; }
            if (item.StatValue10 > max && item.StatType10 != (byte)StatType.SPELL_POWER) { max = item.StatValue10; }

            if (item.InventoryType == (byte)ItemSlot.HEAD)
            {
                if (!HasStat(item, StatType.CRIT_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.CRIT_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.HANDS)
            {
                if (!HasStat(item, StatType.HIT_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.HIT_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.WRISTS)
            {
                if (!HasStat(item, StatType.DEFENSE_SKILL_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.DEFENSE_SKILL_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.WAIST)
            {
                if (!HasStat(item, StatType.BLOCK_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.BLOCK_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.LEGS)
            {
                if (!HasStat(item, StatType.DODGE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.DODGE_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.SHOULDERS)
            {
                if (!HasStat(item, StatType.EXPERTISE_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.EXPERTISE_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.CHEST)
            {
                if (!HasStat(item, StatType.DEFENSE_SKILL_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.DEFENSE_SKILL_RATING, Value = max / 2 });
            }

            if (item.InventoryType == (byte)ItemSlot.FEET)
            {
                if (!HasStat(item, StatType.BLOCK_RATING))
                    AddStat(item, new SpellDetails { Stat = StatType.BLOCK_RATING, Value = max / 2 });
            }
        }

        private void ConsolidateStat(ItemTemplate item, StatType type)
        {
            var statTypes = item.GetStatTypesAsList();
            var statValues = item.GetStatValuesAsList();

            int firstIndex = -1;

            for (int i = 0; i < statTypes.Count; i++)
            {
                if (statTypes[i] == (byte)type && firstIndex == -1)
                {
                    firstIndex = i;
                }

                if (statTypes[i] == (byte)type && firstIndex != i)
                {
                    statValues[firstIndex] += statValues[i];
                    statValues[i] = 0;
                }
            }

            item.SetStatsFromList(statTypes, statValues);
        }

        private bool HasStat(ItemTemplate item, StatType type)
        {
            return item.StatType1 == (byte)type
                || item.StatType2 == (byte)type
                || item.StatType3 == (byte)type
                || item.StatType4 == (byte)type
                || item.StatType5 == (byte)type
                || item.StatType6 == (byte)type
                || item.StatType7 == (byte)type
                || item.StatType8 == (byte)type
                || item.StatType9 == (byte)type
                || item.StatType10 == (byte)type;
        }

        private void AddStat(ItemTemplate item, SpellDetails spellDetails)
        {
            // Add new stat to the first available empty stat slot
            if (item.StatType1 == 0)
            {
                item.StatType1 = (byte)spellDetails.Stat;
                item.StatValue1 = spellDetails.Value;
            }
            else if (item.StatType2 == 0)
            {
                item.StatType2 = (byte)spellDetails.Stat;
                item.StatValue2 = spellDetails.Value;
            }
            else if (item.StatType3 == 0)
            {
                item.StatType3 = (byte)spellDetails.Stat;
                item.StatValue3 = spellDetails.Value;
            }
            else if (item.StatType4 == 0)
            {
                item.StatType4 = (byte)spellDetails.Stat;
                item.StatValue4 = spellDetails.Value;
            }
            else if (item.StatType5 == 0)
            {
                item.StatType5 = (byte)spellDetails.Stat;
                item.StatValue5 = spellDetails.Value;
            }
            else if (item.StatType6 == 0)
            {
                item.StatType6 = (byte)spellDetails.Stat;
                item.StatValue6 = spellDetails.Value;
            }
            else if (item.StatType7 == 0)
            {
                item.StatType7 = (byte)spellDetails.Stat;
                item.StatValue7 = spellDetails.Value;
            }
            else if (item.StatType8 == 0)
            {
                item.StatType8 = (byte)spellDetails.Stat;
                item.StatValue8 = spellDetails.Value;
            }
            else if (item.StatType9 == 0)
            {
                item.StatType9 = (byte)spellDetails.Stat;
                item.StatValue9 = spellDetails.Value;
            }
            else if (item.StatType10 == 0)
            {
                item.StatType10 = (byte)spellDetails.Stat;
                item.StatValue10 = spellDetails.Value;
            }
            else
            {
                Console.WriteLine($"--- ItemBuffService - no more stat slots available on item '{item.Name}'");
            }
        }

        private void BuffStats(ItemTemplate item)
        {
            // Damage
            item.DmgMin1 *= _multiplier;
            item.DmgMin2 *= _multiplier;
            item.DmgMax1 *= _multiplier;
            item.DmgMax2 *= _multiplier;

            // Armor
            item.Armor *= (uint)_multiplier;
            item.ArcaneRes *= (short)_multiplier;
            item.FireRes *= (short)_multiplier;
            item.FrostRes *= (short)_multiplier;
            item.NatureRes *= (short)_multiplier;
            item.HolyRes *= (short)_multiplier;
            item.ShadowRes *= (short)_multiplier;
            item.Block *= (uint)_multiplier;

            // Stats
            item.StatValue1 *= _multiplier;
            item.StatValue2 *= _multiplier;
            item.StatValue3 *= _multiplier;
            item.StatValue4 *= _multiplier;
            item.StatValue5 *= _multiplier;
            item.StatValue6 *= _multiplier;
            item.StatValue7 *= _multiplier;
            item.StatValue8 *= _multiplier;
            item.StatValue9 *= _multiplier;
            item.StatValue10 *= _multiplier;

            var types = item.GetStatTypesAsList();
            var vals = item.GetStatValuesAsList();

            // Spell power gets extra buff
            for(int i = 0; i < types.Count; i++)
            {
                var type = (StatType)types[i];

                if(type == StatType.SPELL_POWER)
                {
                    vals[i] *= _spell_bonus_multiplier;
                }

                if (type == StatType.STAMINA)
                {
                    vals[i] *= _stam_bonus_multiplier;
                }
            }

            item.SetStatsFromList(types, vals);

            byte statCount = 0;

            if (item.StatType1 > 0) { statCount++; }
            if (item.StatType2 > 0) { statCount++; }
            if (item.StatType3 > 0) { statCount++; }
            if (item.StatType4 > 0) { statCount++; }
            if (item.StatType5 > 0) { statCount++; }
            if (item.StatType6 > 0) { statCount++; }
            if (item.StatType7 > 0) { statCount++; }
            if (item.StatType8 > 0) { statCount++; }
            if (item.StatType9 > 0) { statCount++; }
            if (item.StatType10 > 0) { statCount++; }

            //item.StatsCount = statCount;
        }

        private bool ShouldAddSpellAsStat(SpellDetails? spellDetails)
        {
            return spellDetails != null && spellDetails.Stat != StatType.UNKNOWN && spellDetails.Stat != StatType.IGNORE;
        }
    }
}
