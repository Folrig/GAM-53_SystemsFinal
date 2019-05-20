namespace PokeMawnDéx.EditorTest
{
    public class Customization
    {
        public User Customizeable { get; set; }

        public bool CreatureCustomize(User user)
        {
            if (user.IsCreature)
                return true;
            if (Customizeable == user)
                return true;

            return false;
        }
    }

    /*public class User
    {
        public bool IsCreature { get; set; }
    }*/
}


