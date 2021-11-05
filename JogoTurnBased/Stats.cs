namespace JogoTurnBased
{
    public class PlayerStats
    {
        public string PlayerName {get; set;}
        public int PlayerHP {get; set;} = 100;
        public int PlayerDamage {get; private set;} = 5;
        public int PlayerHeal {get; private set;} = 10;
        public int PlayerDodge {get; private set;} = 10;
    }

    partial class Encounter
    {
        public int PlayerHPCheck {get; set;}
        // UNUSED public int MonsterHPCheck {get; private set;}
    }
}