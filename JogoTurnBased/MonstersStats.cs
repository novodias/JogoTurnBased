namespace JogoTurnBased
{
    public class MonsterData
    {
        public string Name { get; set; } = "INVALIDO";
        public int HP { get; set; } = 1;
        public int Damage { get; set; } = 1;
        public int Dodge { get; set; } = 99;
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
            }
            return "";
        }

        public void SlimeMonster()
        {
            Name = "Slime";
            HP = 15;
            Damage = 3;
            Dodge = 5;
        }
        public void TrollMonster()
        {
            Name = "Troll";
            HP = 35;
            Damage = 7;
            Dodge = 2;
        }
    }

    //public class MonsterData
    //{
    //    virtual public string Name { get; set; } = "INVALIDO";
    //    virtual public int HP { get; set; } = 1;
    //    virtual public int Damage { get; set; } = 1;
    //    virtual public int Dodge { get; set; } = 99;
    //    virtual public object InfoMonsterArray(string info)
    //    {
    //        switch (info)
    //        {
    //            case "name":
    //                return Name;
    //            case "hp":
    //                return HP;
    //            case "damage":
    //                return Damage;
    //            case "dodge":
    //                return Dodge;
    //        }
    //        return "";
    //    }
    //}

    //public class SlimeMonster : MonsterData
    //{
    //    // *** SLIME ***
    //    // DATA
    //    override public string Name { get; set; } = "Slime";
    //    override public int HP { get; set; } = 15;
    //    override public int Damage { get; set; } = 6;
    //    override public int Dodge { get; set; } = 5;
    //    public override object InfoMonsterArray(string info)
    //    {
    //        return base.InfoMonsterArray(info);
    //    }
    //}

    //public class TrollMonster : MonsterData
    //{
    //    // *** TROLL ***
    //    // DATA
    //    override public string Name { get; set; } = "Troll";
    //    override public int HP { get; set; } = 35;
    //    override public int Damage { get; set; } = 7;
    //    override public int Dodge { get; set; } = 2;
    //    public override object InfoMonsterArray(string info)
    //    {
    //        return base.InfoMonsterArray(info);
    //    }
    //}
}