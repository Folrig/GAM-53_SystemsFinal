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
    private Condition _condition;
    private GameObject _avatar;
    public List<BattleMove> moves = new List<BattleMove>();
    #endregion

    #region Properties
    public string Name { get { return this._name; } set { _name = value; } }
    public bool IsFainted { get { return this._isFainted; } }
    public int CurrentXP { get { return this._xp; } }
    public int Health { get { return this._health; } }
    public int MaxHealth { get { return this._maxHealth; } }
    public int Power { get { return this._power; } }
    public int Agility { get { return this._agility; } }
    public int Level { get { return this._level; } }
    public GameObject Avatar { get { return this._avatar; } }
    public Attribute Attrib { get { return this._attribute; } }
    #endregion

    #region Methods
    public BattleCreature() { }

    public BattleCreature(string name, Attribute attribute, int maxHealth, int health, int power, int agility)
    {
        this._name = name;
        this._attribute = attribute;
        this._maxHealth = maxHealth;
        if (health > this._maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            this._health = health;
        }
        this._power = power;
        this._agility = agility;
        this._condition = Condition.Normal;
    }

    public void ReceiveDamage(int damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }
        else if (damage >= this._health)
        {
            this._health = 0;
            this._isFainted = true;
        }

        this._health -= damage;
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
        this._health = this._maxHealth;
        CureCondition();
    }

    public void GainXP(int delta)
    {
        if (delta < 0)
        {
            Debug.LogError("XP cannot be negative.");
            return;
        }
        else
        {
            if (delta >= NextLevelXP())
            {
                LevelUp();
            }
            this._xp += delta;
        }
    }

    public int NextLevelXP()
    {
        // Calculations for next level (I threw an arbitrary formula in, feel free to change -- Steve)
        int levelGoal = 50 + 50 * Mathf.RoundToInt(Mathf.Pow(1.25f, (float)this._level));
        int xp = levelGoal - this._xp;
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

        // Insert level up benefits to stats here
    }

    public void InflictCondition(Condition condition)
    {
        this._condition = condition;
    }

    public void CureCondition()
    {
        this._condition = Condition.Normal;
    }

    public void SetAvatar(GameObject newAvatar)
    {
        this._avatar = newAvatar;
    }
    #endregion
}
