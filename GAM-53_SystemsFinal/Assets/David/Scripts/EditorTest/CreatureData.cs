namespace PokeMawnDéx.EditorTest
{
    public class CreatureData 
    {
        public User CreatureName { get; set; }

        public bool CreatureDataBy(User  user)
        {
            if (user.IsCreature)
                return true;
            if (user.IsBattleCreature)
                return true;
            if (CreatureName == user)
                return true;

            return false;
        }
    }

    public class User
    {
        public bool IsCreature { get; set; }
        public bool IsBattleCreature { get; set; }
    }

    public class BattleCreature
    {
        
    }
}