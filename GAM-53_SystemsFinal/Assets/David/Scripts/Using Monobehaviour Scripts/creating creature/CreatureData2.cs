public class CreatureData2 
{
    public int name, health;

   public string Type , Land, Sky;
    public string PowerUp ,Water, Fire, Earth;
	

    public void CreatureData(int _name, int _health, string _type, string _powerUp ,string _powerOption, string _typeOption)
    {
        name = _name;
        health = _health;

        Type = _type;
        PowerUp = _powerUp;

        Land = _typeOption;
        Sky = _typeOption;

        Water = _powerOption;
        Fire = _powerOption;
        Earth = _powerOption;
    }


}
