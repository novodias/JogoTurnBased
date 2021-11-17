namespace JogoTurnBased
{
    public class PlayerStatsName
    {
        public string PlayerName { get; private set; }
        public void GetPlayerName(string name)
        {
            PlayerName = name;
        }
        public string ReturnPlayerName()
        {
            return PlayerName;
        }
    }
    public class ActionClass
    {
        private string Action { get; set; }
        public void GetAction(string action)
        {
            Action = action;
        }
        public string ReturnAction()
        {
            return Action;
        }
    }
    public class PlayerStats
    {
        public int HP {get; set;} = 100;
        public int Damage {get; private set;} = 5;
        public int Heal {get; private set;} = 10;
        public int Dodge {get; private set;} = 10;
        public int EXP { get; set; } = 0;
        public int EXPtoLevelUP { get; set; } = 10;

    }

    partial class Encounter
    {
        public int PlayerHPCheck {get; set;}
        // UNUSED public int MonsterHPCheck {get; private set;}
    }
}