using System;
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
    private bool _isFainted;
    private int _level;
    private int _xp;
    private GameObject _avatar;
    public List<BattleMove> moves = new List<BattleMove>();
    #endregion

    #region Properties
    public string Name { get { return this._name; } set { _name = value; } }
    public bool IsFainted { get { return this._isFainted; } }
    public int CurrentXP { get { return this._xp; } }
    public int Health { get { return this._health; } }
    public int MaxHealth { get { return this._maxHealth; } }
    #endregion

    #region Methods
    public AttackResult ReceiveAttack(int damage, BattleMove move)
    {
        // Discuss how to determine the result, this might possibly be moved to the Battle class and the creature would take the result
        AttackResult attack = new AttackResult();

        return attack;
    }

    public void AdjustHealth(int delta)
    {
        this._health += delta;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        if (_health <= 0)
        {
            _health = 0;
            _isFainted = true;
        }
    }

    public void Revive()
    {
        this._isFainted = false;
    }

    public void GainXP(int delta)
    {
        if (delta < 0)
        {
            Debug.LogError("XP cannot be negative.");
        }
        else
        {
            this._xp += delta;
        }
    }

    public int NextLevelXP()
    {
        // Calculations for next level
        int xp = 0;
        return xp;
    }

    private void LevelUp()
    {
        this._level++;
        
        if (this._level < 1)
        {
            Debug.LogError("BattleCreature.LevelUp() - Level cannot be less than 1");
            throw new NotSupportedException();
        }
    }

    public void CureCondition()
    {

    }
    #endregion
}
