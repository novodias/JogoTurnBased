namespace JogoTurnBased
{
    public class MonsterData
    {
        public string Name { get; set; } = "INVALIDO";
        public int HP { get; set; } = 1;
        public int Damage { get; set; } = 1;
        public int Dodge { get; set; } = 99;
        public int EXP { get; set; } = 0;
        public object InfoMonsterArray(string info)
        {
            switch (info)
            {
                case "name":
                    return Name;
                case "hp":
                    return HP;
                case "damage":
                    return Damage;
                case "dodge":
                    return Dodge;
                case "exp":
                    return EXP;
            }
            return "";
        }

        public void SlimeMonster()
        {
            Name = "Slime";
            HP = 15;
            Damage = 3;
            Dodge = 2;
            EXP = 2; // temporario
        }
        public void TrollMonster()
        {
            Name = "Troll";
            HP = 35;
            Damage = 7;
            Dodge = 2;
            EXP = 10;
        }
        public void GoblinMonster()
        {
            Name = "Goblin";
            HP = 15;
            Damage = 4;
            Dodge = 5;
            EXP = 5;
        }
    }
}