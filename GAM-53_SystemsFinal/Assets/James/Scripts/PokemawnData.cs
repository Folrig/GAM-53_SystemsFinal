using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemawnData 
{
    public string name;
    public Attribute attribute;
    public int health;
    public int maxHealth;
    public int power;
    public int agility;
    public bool isFainted;
    public int level;
    public int xp;
    public Condition condition;
    public GameObject avatar;
    public List<BattleMove> moves = new List<BattleMove>();
}
