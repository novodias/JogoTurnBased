using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoTurnBased
{
    class MessageTxt
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    partial class MessageClass
    {
        private static MessageTxt[] messages =
        {
            // new MessageTxt(){ Message = "", Name = "", Type = "" },

            #region Explore.cs
            new MessageTxt(){ Message = "", Name = "MesDungeonFound", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "MesDungeonExplore", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "ConDungeonFoundNothing", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "BigChungus", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "ThanosT", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "SusAmogusD", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "HpPotionFound01", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "HpPotionFound02", Type = "explore" },
            new MessageTxt(){ Message = "", Name = "ItemAndExp", Type = "explore" },
            #endregion

            #region Experience.cs
            new MessageTxt(){ Message = "", Name = "HpMax", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "Attack", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "Dodge", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "Heal", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "NewTry", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "LevelUp", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "Choose", Type = "exp" },
            new MessageTxt(){ Message = "", Name = "ExpTotal", Type = "exp" },
            #endregion

            #region Cmmds.cs
            new MessageTxt(){ Message = "", Name = "ExploreCmmds", Type = "cmmds" },
            new MessageTxt(){ Message = "", Name = "CombatCmmds", Type = "cmmds" },
            new MessageTxt(){ Message = "", Name = "BeginCmmds", Type = "cmmds" },
            #endregion

            #region Combat.cs
            new MessageTxt(){ Message = "", Name = "InvalidCommand", Type = "combat" },
            new MessageTxt(){ Message = "", Name = "EndBattle01", Type = "combat" },
            new MessageTxt(){ Message = "", Name = "EndBattle02", Type = "combat" },
            new MessageTxt(){ Message = "", Name = "NewTry", Type = "combat" },
            #endregion

            #region CombatType.cs
            new MessageTxt(){ Message = "", Name = "CriticDamage", Type = "combattype" },
            new MessageTxt(){ Message = "", Name = "ReturnOneDamage", Type = "combattype" },
            new MessageTxt(){ Message = "", Name = "Damage", Type = "combattype" },
            new MessageTxt(){ Message = "", Name = "Dodge", Type = "combattype" },
            new MessageTxt(){ Message = "", Name = "Heal", Type = "combattype" },
            new MessageTxt(){ Message = "", Name = "FailedHeal", Type = "combattype" },
            #endregion

            #region Encounter.cs
            new MessageTxt(){ Message = "", Name = "PlayerHP", Type = "encounter" },
            new MessageTxt(){ Message = "", Name = "MonsterHP", Type = "encounter" },
            new MessageTxt(){ Message = "", Name = "Todo", Type = "encounter" },
            new MessageTxt(){ Message = "", Name = "YouDied", Type = "encounter" },
            new MessageTxt(){ Message = "", Name = "MonsterDead", Type = "encounter" },
            #endregion

            #region Player.cs
            new MessageTxt(){ Message = "", Name = "InsertName", Type = "player" }
            #endregion
        };
    }
}
