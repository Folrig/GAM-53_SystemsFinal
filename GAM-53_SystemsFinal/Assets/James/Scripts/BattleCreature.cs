using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Does not derive from MonoBehaviour as per UML diagram but this could be simplification of the diagram
[Serializable]
public class BattleCreature
{
    #region Variables
    [SerializeField] private string _name;
    [SerializeField] private Attribute _attribute;
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _power;
    [SerializeField] private int _agility;
    [SerializeField] private bool _isFainted;
    [SerializeField] private int _level;
    [SerializeField] private int _xp;
    [SerializeField] private Condition _condition;
    [SerializeField] private GameObject _avatar;
    [SerializeField] public List<BattleMove> moves = new List<BattleMove>();
    #endregion

    #region Properties
    public string Name { get { return this._name; } set { _name = value; } }
    public bool IsFainted { get { return this._isFainted; } set { _isFainted = value; } }
    public int CurrentXP { get { return this._xp; } set { _xp = value; } }
    public int Health { get { return this._health; } set { _health = value; } }
    public int MaxHealth { get { return this._maxHealth; } set { _maxHealth = value; } }
    public int Power { get { return this._power; } set { _power = value; } }
    public int Agility { get { return this._agility; } set { _agility = value; } }
    public int Level { get { return this._level; } set { _level = value; } }
    public Condition Condition { get { return this._condition; } set { _condition = value; } }
    public GameObject Avatar { get { return this._avatar; } set { _avatar = value; } }
    public Attribute Attribute { get { return this._attribute; } set { _attribute = value; } }
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
