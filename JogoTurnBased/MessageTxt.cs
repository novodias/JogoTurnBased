using System;

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
            new MessageTxt(){ Message = String.Format(""), Name = "MesDungeonFound", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "MesDungeonExplore", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "ConDungeonFoundNothing", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "BigChungus", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "ThanosT", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "SusAmogusD", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "HpPotionFound01", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "HpPotionFound02", Type = "explore" },
            new MessageTxt(){ Message = String.Format(""), Name = "ItemAndExp", Type = "explore" },
            #endregion

            #region Experience.cs
            new MessageTxt(){ Message = String.Format(""), Name = "HpMax", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "Attack", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "Dodge", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "Heal", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "NewTry", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "LevelUp", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "Choose", Type = "exp" },
            new MessageTxt(){ Message = String.Format(""), Name = "ExpTotal", Type = "exp" },
            #endregion

            #region Cmmds.cs
            new MessageTxt(){ Message = String.Format(""), Name = "ExploreCmmds", Type = "cmmds" },
            new MessageTxt(){ Message = String.Format(""), Name = "CombatCmmds", Type = "cmmds" },
            new MessageTxt(){ Message = String.Format(""), Name = "BeginCmmds", Type = "cmmds" },
            #endregion

            #region Combat.cs
            new MessageTxt(){ Message = String.Format(""), Name = "InvalidCommand", Type = "combat" },
            new MessageTxt(){ Message = String.Format(""), Name = "EndBattle01", Type = "combat" },
            new MessageTxt(){ Message = String.Format(""), Name = "EndBattle02", Type = "combat" },
            new MessageTxt(){ Message = String.Format(""), Name = "NewTry", Type = "combat" },
            #endregion

            #region CombatType.cs
            new MessageTxt(){ Message = String.Format(""), Name = "CriticDamage", Type = "combattype" },
            new MessageTxt(){ Message = String.Format(""), Name = "ReturnOneDamage", Type = "combattype" },
            new MessageTxt(){ Message = String.Format(""), Name = "Damage", Type = "combattype" },
            new MessageTxt(){ Message = String.Format(""), Name = "Dodge", Type = "combattype" },
            new MessageTxt(){ Message = String.Format(""), Name = "Heal", Type = "combattype" },
            new MessageTxt(){ Message = String.Format(""), Name = "FailedHeal", Type = "combattype" },
            #endregion

            #region Encounter.cs
            new MessageTxt(){ Message = String.Format(""), Name = "PlayerHP", Type = "encounter" },
            new MessageTxt(){ Message = String.Format(""), Name = "MonsterHP", Type = "encounter" },
            new MessageTxt(){ Message = String.Format(""), Name = "Todo", Type = "encounter" },
            new MessageTxt(){ Message = String.Format(""), Name = "YouDied", Type = "encounter" },
            new MessageTxt(){ Message = String.Format(""), Name = "MonsterDead", Type = "encounter" },
            #endregion

            #region Player.cs
            new MessageTxt(){ Message = String.Format(""), Name = "InsertName", Type = "player" },
            #endregion

            #region Message.cs
            new MessageTxt(){ Message = String.Format(""), Name = "Hello", Type = "message" },
            new MessageTxt(){ Message = String.Format(""), Name = "Walk", Type = "message" },
            #endregion

            new MessageTxt(){ Message = "", Name = "Tpose", Type = "combat" }
        };
    }
}
