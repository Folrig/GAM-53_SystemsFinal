using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Does not derive from MonoBehaviour as per UML diagram but this could be simplification of the diagram
public class BattleCreature
{
    #region Variables
    private string _name;
    private Attribute _attribute;
    private int _health;
    private int _maxHealth;
    private int _power;
    private int _agility;
    private bool _fainted;
    private int _level;
    private int _xp;
    private GameObject _avatar;
    public List<BattleMove> moves = new List<BattleMove>();
    #endregion

    #region Properties
    public string Name { get { return this._name; } set { _name = value; } }
    #endregion

    #region Methods
    void Start()
    {
		
	}
	
	void Update()
    {
		
	}
    #endregion
}
