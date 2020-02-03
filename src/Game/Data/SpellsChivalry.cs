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

using ClassicUO.Game.Managers;

namespace ClassicUO.Game.Data
{
    internal static class SpellsChivalry
    {
        private static readonly Dictionary<int, SpellDefinition> _spellsDict;

        static SpellsChivalry()
        {
            _spellsDict = new Dictionary<int, SpellDefinition>
            {
                // Spell List
                {
                    1, new SpellDefinition(Language.Language.UI_SpellName_CleansebyFire, 201, 0x5100, 0x5100, "Expor Flamus", 10, 5, 10, TargetType.Beneficial, Reagents.None)
                },
                {
                    2, new SpellDefinition(Language.Language.UI_SpellName_CloseWounds, 202, 0x5101, 0x5101, "Obsu Vulni", 10, 0, 10, TargetType.Beneficial, Reagents.None)
                },
                {
                    3, new SpellDefinition(Language.Language.UI_SpellName_ConsecrateWeapon, 203, 0x5102, 0x5102, "Consecrus Arma", 10, 15, 10, TargetType.Neutral, Reagents.None)
                },
                {
                    4, new SpellDefinition(Language.Language.UI_SpellName_DispelEvil, 204, 0x5103, 0x5103, "Dispiro Malas", 10, 35, 10, TargetType.Neutral, Reagents.None)
                },
                {
                    5, new SpellDefinition(Language.Language.UI_SpellName_DivineFury, 205, 0x5104, 0x5104, "Divinum Furis", 10, 25, 10, TargetType.Neutral, Reagents.None)
                },
                {
                    6, new SpellDefinition(Language.Language.UI_SpellName_EnemyofOne, 206, 0x5105, 0x5105, "Forul Solum", 20, 45, 10, TargetType.Neutral, Reagents.None)
                },
                {
                    7, new SpellDefinition(Language.Language.UI_SpellName_HolyLight, 207, 0x5106, 0x5106, "Augus Luminos", 20, 55, 10, TargetType.Harmful, Reagents.None)
                },
                {
                    8, new SpellDefinition(Language.Language.UI_SpellName_NobleSacrifice, 208, 0x5107, 0x5107, "Dium Prostra", 20, 65, 30, TargetType.Beneficial, Reagents.None)
                },
                {
                    9, new SpellDefinition(Language.Language.UI_SpellName_RemoveCurse, 209, 0x5108, 0x5108, "Extermo Vomica", 20, 5, 10, TargetType.Beneficial, Reagents.None)
                },
                {
                    10, new SpellDefinition(Language.Language.UI_SpellName_SacredJourney, 210, 0x5109, 0x5109, "Sanctum Viatas", 20, 5, 10, TargetType.Neutral, Reagents.None)
                }
            };
        }

        public static string SpellBookName { get; set; } = SpellBookType.Chivalry.ToString();

        public static IReadOnlyDictionary<int, SpellDefinition> GetAllSpells => _spellsDict;
        internal static int MaxSpellCount => _spellsDict.Count;

        public static SpellDefinition GetSpell(int spellIndex)
        {
            if (_spellsDict.TryGetValue(spellIndex, out SpellDefinition spell))
                return spell;

            return SpellDefinition.EmptySpell;
        }

        public static void SetSpell(int id, in SpellDefinition newspell)
        {
            _spellsDict[id] = newspell;
        }

        internal static void Clear()
        {
            _spellsDict.Clear();
        }
    }
}