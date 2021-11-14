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
        public int PlayerHP {get; set;} = 100;
        public int PlayerDamage {get; private set;} = 5;
        public int PlayerHeal {get; private set;} = 10;
        public int PlayerDodge {get; private set;} = 10;
        public int PlayerEXP { get; set; } = 0;
        public int PlayerEXPtoLevelUP { get; set; } = 10;

    }

    partial class Encounter
    {
        public int PlayerHPCheck {get; set;}
        // UNUSED public int MonsterHPCheck {get; private set;}
    }
}