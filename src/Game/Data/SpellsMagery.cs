#region license

//  Copyright (C) 2019 ClassicUO Development Community on Github
//
//	This project is an alternative client for the game Ultima Online.
//	The goal of this is to develop a lightweight client considering 
//	new technologies.  
//      
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <https://www.gnu.org/licenses/>.

#endregion

using System.Collections.Generic;
using System.Linq;

using ClassicUO.Game.Managers;
using ClassicUO.Utility;

namespace ClassicUO.Game.Data
{
    internal static class SpellsMagery
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        private static string[] _spRegsChars;

        static SpellsMagery()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // first circle
                {
                    1, new SpellDefinition(Language.Language.UI_SpellName_Clumsy, 1, 0x1B58, "Uus Jux", TargetType.Harmful, Reagents.Bloodmoss, Reagents.Nightshade)
                },
                {
                    2, new SpellDefinition(Language.Language.UI_SpellName_CreateFood, 2, 0x1B59, "In Mani Ylem", TargetType.Neutral, Reagents.Garlic, Reagents.Ginseng, Reagents.MandrakeRoot)
                },
                {
                    3, new SpellDefinition(Language.Language.UI_SpellName_Feeblemind, 3, 0x1B5A, "Rel Wis", TargetType.Harmful, Reagents.Nightshade, Reagents.Ginseng)
                },
                {
                    4, new SpellDefinition(Language.Language.UI_SpellName_Heal, 4, 0x1B5B, "In Mani", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng, Reagents.SpidersSilk)
                },
                {
                    5, new SpellDefinition(Language.Language.UI_SpellName_MagicArrow, 5, 0x1B5C, "In Por Ylem", TargetType.Harmful, Reagents.SulfurousAsh)
                },
                {
                    6, new SpellDefinition(Language.Language.UI_SpellName_NightSight, 6, 0x1B5D, "In Lor", TargetType.Beneficial, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    7, new SpellDefinition(Language.Language.UI_SpellName_ReactiveArmor, 7, 0x1B5E, "Flam Sanct", TargetType.Beneficial, Reagents.Garlic, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    8, new SpellDefinition(Language.Language.UI_SpellName_Weaken, 8, 0x1B5F, "Des Mani", TargetType.Harmful, Reagents.Garlic, Reagents.Nightshade)
                },
                // second circle
                {
                    9, new SpellDefinition(Language.Language.UI_SpellName_Agility, 9, 0x1B60, "Ex Uus", TargetType.Beneficial, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                {
                    10, new SpellDefinition(Language.Language.UI_SpellName_Cunning, 10, 0x1B61, "Uus Wis", TargetType.Beneficial, Reagents.Nightshade, Reagents.MandrakeRoot)
                },
                {
                    11, new SpellDefinition(Language.Language.UI_SpellName_Cure, 11, 0x1B62, "An Nox", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng)
                },
                {
                    12, new SpellDefinition(Language.Language.UI_SpellName_Harm, 12, 0x1B63, "An Mani", TargetType.Harmful, Reagents.Nightshade, Reagents.SpidersSilk)
                },
                {
                    13, new SpellDefinition(Language.Language.UI_SpellName_MagicTrap, 13, 0x1B64, "In Jux", TargetType.Neutral, Reagents.Garlic, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    14, new SpellDefinition(Language.Language.UI_SpellName_MagicUntrap, 14, 0x1B65, "An Jux", TargetType.Neutral, Reagents.Bloodmoss, Reagents.SulfurousAsh)
                },
                {
                    15, new SpellDefinition(Language.Language.UI_SpellName_Protection, 15, 0x1B66, "Uus Sanct", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng, Reagents.SulfurousAsh)
                },
                {
                    16, new SpellDefinition(Language.Language.UI_SpellName_Strength, 16, 0x1B67, "Uus Mani", TargetType.Beneficial, Reagents.MandrakeRoot, Reagents.Nightshade)
                },
                // third circle
                {
                    17, new SpellDefinition(Language.Language.UI_SpellName_Bless, 17, 0x1B68, "Rel Sanct", TargetType.Beneficial, Reagents.Garlic, Reagents.MandrakeRoot)
                },
                {
                    18, new SpellDefinition(Language.Language.UI_SpellName_Fireball, 18, 0x1B69, "Vas Flam", TargetType.Harmful, Reagents.BlackPearl)
                },
                {
                    19, new SpellDefinition(Language.Language.UI_SpellName_MagicLock, 19, 0x1B6a, "An Por", TargetType.Neutral, Reagents.Bloodmoss, Reagents.Garlic, Reagents.SulfurousAsh)
                },
                {
                    20, new SpellDefinition(Language.Language.UI_SpellName_Poison, 20, 0x1B6b, "In Nox", TargetType.Harmful, Reagents.Nightshade)
                },
                {
                    21, new SpellDefinition(Language.Language.UI_SpellName_Telekinesis, 21, 0x1B6c, "Ort Por Ylem", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                {
                    22, new SpellDefinition(Language.Language.UI_SpellName_Teleport, 22, 0x1B6d, "Rel Por", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                {
                    23, new SpellDefinition(Language.Language.UI_SpellName_Unlock, 23, 0x1B6e, "Ex Por", TargetType.Neutral, Reagents.Bloodmoss, Reagents.SulfurousAsh)
                },
                {
                    24, new SpellDefinition(Language.Language.UI_SpellName_WallofStone, 24, 0x1B6f, "In Sanct Ylem", TargetType.Neutral, Reagents.Bloodmoss, Reagents.Garlic)
                },
                // fourth circle
                {
                    25, new SpellDefinition(Language.Language.UI_SpellName_ArchCure, 25, 0x1B70, "Vas An Nox", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng, Reagents.MandrakeRoot)
                },
                {
                    26, new SpellDefinition(Language.Language.UI_SpellName_ArchProtection, 26, 0x1B71, "Vas Uus Sanct", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    27, new SpellDefinition(Language.Language.UI_SpellName_Curse, 27, 0x1B72, "Des Sanct", TargetType.Harmful, Reagents.Garlic, Reagents.Nightshade, Reagents.SulfurousAsh)
                },
                {
                    28, new SpellDefinition(Language.Language.UI_SpellName_FireField, 28, 0x1B73, "In Flam Grav", TargetType.Neutral, Reagents.BlackPearl, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    29, new SpellDefinition(Language.Language.UI_SpellName_GreaterHeal, 29, 0x1B74, "In Vas Mani", TargetType.Beneficial, Reagents.Garlic, Reagents.Ginseng, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    30, new SpellDefinition(Language.Language.UI_SpellName_Lightning, 30, 0x1B75, "Por Ort Grav", TargetType.Harmful, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    31, new SpellDefinition(Language.Language.UI_SpellName_ManaDrain, 31, 0x1B76, "Ort Rel", TargetType.Harmful, Reagents.BlackPearl, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    32, new SpellDefinition(Language.Language.UI_SpellName_Recall, 32, 0x1B77, "Kal Ort Por", TargetType.Neutral, Reagents.BlackPearl, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                // fifth circle
                {
                    33, new SpellDefinition(Language.Language.UI_SpellName_BladeSpirits, 33, 0x1B78, "In Jux Hur Ylem", TargetType.Neutral, Reagents.BlackPearl, Reagents.MandrakeRoot, Reagents.Nightshade)
                },
                {
                    34, new SpellDefinition(Language.Language.UI_SpellName_DispelField, 34, 0x1B79, "An Grav", TargetType.Neutral, Reagents.BlackPearl, Reagents.Garlic, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    35, new SpellDefinition(Language.Language.UI_SpellName_Incognito, 35, 0x1B7a, "Kal In Ex", TargetType.Neutral, Reagents.Bloodmoss, Reagents.Garlic, Reagents.Nightshade)
                },
                {
                    36, new SpellDefinition(Language.Language.UI_SpellName_MagicReflection, 36, 0x1B7b, "In Jux Sanct", TargetType.Beneficial, Reagents.Garlic, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    37, new SpellDefinition(Language.Language.UI_SpellName_MindBlast, 37, 0x1B7c, "Por Corp Wis", TargetType.Harmful, Reagents.BlackPearl, Reagents.MandrakeRoot, Reagents.Nightshade, Reagents.SulfurousAsh)
                },
                {
                    38, new SpellDefinition(Language.Language.UI_SpellName_Paralyze, 38, 0x1B7d, "An Ex Por", TargetType.Harmful, Reagents.Garlic, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    39, new SpellDefinition(Language.Language.UI_SpellName_PoisonField, 39, 0x1B7e, "In Nox Grav", TargetType.Neutral, Reagents.BlackPearl, Reagents.Nightshade, Reagents.SpidersSilk)
                },
                {
                    40, new SpellDefinition(Language.Language.UI_SpellName_SummonCreature, 40, 0x1B7f, "Kal Xen", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                // sixth circle
                {
                    41, new SpellDefinition(Language.Language.UI_SpellName_Dispel, 41, 0x1B80, "An Ort", TargetType.Neutral, Reagents.Garlic, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    42, new SpellDefinition(Language.Language.UI_SpellName_EnergyBolt, 42, 0x1B81, "Corp Por", TargetType.Harmful, Reagents.BlackPearl, Reagents.Nightshade)
                },
                {
                    43, new SpellDefinition(Language.Language.UI_SpellName_Explosion, 43, 0x1B82, "Vas Ort Flam", TargetType.Harmful, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                {
                    44, new SpellDefinition(Language.Language.UI_SpellName_Invisibility, 44, 0x1B83, "An Lor Xen", TargetType.Beneficial, Reagents.Bloodmoss, Reagents.Nightshade)
                },
                {
                    45, new SpellDefinition(Language.Language.UI_SpellName_Mark, 45, 0x1B84, "Kal Por Ylem", TargetType.Neutral, Reagents.BlackPearl, Reagents.Bloodmoss, Reagents.MandrakeRoot)
                },
                {
                    46, new SpellDefinition(Language.Language.UI_SpellName_MassCurse, 46, 0x1B85, "Vas Des Sanct", TargetType.Harmful, Reagents.Garlic, Reagents.MandrakeRoot, Reagents.Nightshade, Reagents.SulfurousAsh)
                },
                {
                    47, new SpellDefinition(Language.Language.UI_SpellName_ParalyzeField, 47, 0x1B86, "In Ex Grav", TargetType.Neutral, Reagents.BlackPearl, Reagents.Ginseng, Reagents.SpidersSilk)
                },
                {
                    48, new SpellDefinition(Language.Language.UI_SpellName_Reveal, 48, 0x1B87, "Wis Quas", TargetType.Neutral, Reagents.Bloodmoss, Reagents.SulfurousAsh)
                },
                // seventh circle
                {
                    49, new SpellDefinition(Language.Language.UI_SpellName_ChainLightning, 49, 0x1B88, "Vas Ort Grav", TargetType.Harmful, Reagents.BlackPearl, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    50, new SpellDefinition(Language.Language.UI_SpellName_EnergyField, 50, 0x1B89, "In Sanct Grav", TargetType.Neutral, Reagents.BlackPearl, Reagents.MandrakeRoot, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    51, new SpellDefinition(Language.Language.UI_SpellName_Flamestrike, 51, 0x1B8a, "Kal Vas Flam", TargetType.Harmful, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    52, new SpellDefinition(Language.Language.UI_SpellName_GateTravel, 52, 0x1B8b, "Vas Rel Por", TargetType.Neutral, Reagents.BlackPearl, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    53, new SpellDefinition(Language.Language.UI_SpellName_ManaVampire, 53, 0x1B8c, "Ort Sanct", TargetType.Harmful, Reagents.BlackPearl, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    54, new SpellDefinition(Language.Language.UI_SpellName_MassDispel, 54, 0x1B8d, "Vas An Ort", TargetType.Neutral, Reagents.BlackPearl, Reagents.Garlic, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    55, new SpellDefinition(Language.Language.UI_SpellName_MeteorSwarm, 55, 0x1B8e, "Flam Kal Des Ylem", TargetType.Harmful, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    56, new SpellDefinition(Language.Language.UI_SpellName_Polymorph, 56, 0x1B8f, "Vas Ylem Rel", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                // eighth circle
                {
                    57, new SpellDefinition(Language.Language.UI_SpellName_Earthquake, 57, 0x1B90, "In Vas Por", TargetType.Harmful, Reagents.Bloodmoss, Reagents.Ginseng, Reagents.MandrakeRoot, Reagents.SulfurousAsh)
                },
                {
                    58, new SpellDefinition(Language.Language.UI_SpellName_EnergyVortex, 58, 0x1B91, "Vas Corp Por", TargetType.Neutral, Reagents.BlackPearl, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.Nightshade)
                },
                {
                    59, new SpellDefinition(Language.Language.UI_SpellName_Resurrection, 59, 0x1B92, "An Corp", TargetType.Beneficial, Reagents.Bloodmoss, Reagents.Ginseng, Reagents.Garlic)
                },
                {
                    60, new SpellDefinition(Language.Language.UI_SpellName_AirElemental, 60, 0x1B93, "Kal Vas Xen Hur", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    61, new SpellDefinition(Language.Language.UI_SpellName_SummonDaemon, 61, 0x1B94, "Kal Vas Xen Corp", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    62, new SpellDefinition(Language.Language.UI_SpellName_EarthElemental, 62, 0x1B95, "Kal Vas Xen Ylem", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                },
                {
                    63, new SpellDefinition(Language.Language.UI_SpellName_FireElemental, 63, 0x1B96, "Kal Vas Xen Flam", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk, Reagents.SulfurousAsh)
                },
                {
                    64, new SpellDefinition(Language.Language.UI_SpellName_WaterElemental, 64, 0x1B97, "Kal Vas Xen An Flam", TargetType.Neutral, Reagents.Bloodmoss, Reagents.MandrakeRoot, Reagents.SpidersSilk)
                }
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Magery.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static string[] CircleNames { get; } =
        {
            "First Circle", "Second Circle", "Third Circle", "Fourth Circle", "Fifth Circle", "Sixth Circle", "Seventh Circle", "Eighth Circle"
        };

        public static string[] SpecialReagentsChars
        {
            get
            {
                if (_spRegsChars == null)
                {
                    _spRegsChars = new string[_spellsDict.Max(o => o.Key)];

                    for (int i = _spRegsChars.Length; i > 0; --i)
                    {
                        if (_spellsDict.TryGetValue(i, out SpellDefinition sd))
                            _spRegsChars[i - 1] = StringHelper.RemoveUpperLowerChars(sd.PowerWords);
                        else
                            _spRegsChars[i - 1] = string.Empty;
                    }
                }

                return _spRegsChars;
            }
        }

        public static SpellDefinition GetSpell(int index)
        {
            return _spellsDict.TryGetValue(index, out SpellDefinition spell) ? spell : SpellDefinition.EmptySpell;
        }

        public static void SetSpell(int id, in SpellDefinition newspell)
        {
            _spRegsChars = null;
            _spellsDict[id] = newspell;
        }

        internal static void Clear()
        {
            _spellsDict.Clear();
        }
    }
}