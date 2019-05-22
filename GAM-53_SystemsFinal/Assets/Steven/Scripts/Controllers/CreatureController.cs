using UnityEngine;

abstract public class CreatureController
{
    public readonly BattleCreature creature;
    protected CreatureBattle battleController;

    public CreatureController(BattleCreature creature, CreatureBattle battleController)
    {
        if (creature == null)
            throw new System.Exception("Creature of a CreatureController cannot be null.");
        if (battleController == null)
            throw new System.Exception("Battle Controller of a CreatureController cannot be null.");
        
        this.creature = creature;
        this.battleController = battleController;
    }

    public AttackResult ReceiveAttack(BattleMove attack, int strength, int agility)
    {
        AttackResult result = new AttackResult() { isDodged = false, isStrong = false, isWeak = false };

        float dodgeChance = Mathf.Round(50f * agility / creature.Agility) / 1000f;
        result.isDodged = Random.value < dodgeChance;

        if (result.isDodged)
        {
            result.damageTaken = 0;
            return result;
        }
        
        int vulnerability = CompareAttributes(attack.attribute, creature.Attribute);
        if (vulnerability == 1)
        {
            result.isStrong = true;
        }
        else if (vulnerability == -1)
        {
            result.isWeak = true;
        }

        int damage = Mathf.RoundToInt(Random.Range(0.75f, 1.0f) * (float)strength * (1.0f - 0.5f * (float)vulnerability));
        if (damage > creature.Health)
        {
            damage = creature.Health;
        }
        result.damageTaken = damage;
        creature.ReceiveDamage(damage);

        return result;
    }

    abstract public void GetAttack();

    // If attack is strong against defender, returns 1
    // If attack is weak against defedner, returns -1
    // Otherwise, returns 0;
    protected int CompareAttributes(Attribute attackAttribute, Attribute defenderAttribute)
    {
        // Not sure what the intended dichotomies are here, so I just guessed.
        // If it's wrong I can adjust it later.
        switch (attackAttribute)
        {
            case Attribute.Fire:
                switch (defenderAttribute)
                {
                    case Attribute.Fire:
                    case Attribute.Water:
                        return -1;
                    case Attribute.Physical:
                        return 1;
                    default:
                        return 0;
                }
            case Attribute.Metal:
                switch (defenderAttribute)
                {
                    case Attribute.Metal:
                    case Attribute.Fire:
                        return -1;
                    case Attribute.Nature:
                        return 1;
                    default:
                        return 0;
                }
            case Attribute.Nature:
                switch (defenderAttribute)
                {
                    case Attribute.Nature:
                    case Attribute.Fire:
                        return -1;
                    case Attribute.Psychic:
                        return 1;
                    default:
                        return 0;
                }
            case Attribute.Physical:
                switch(defenderAttribute)
                {
                    case Attribute.Physical:
                    case Attribute.Psychic:
                        return -1;
                    case Attribute.Water:
                        return 1;
                    default:
                        return 0;
                }
            case Attribute.Psychic:
                switch (defenderAttribute)
                {
                    case Attribute.Psychic:
                    case Attribute.Metal:
                        return -1;
                    case Attribute.Physical:
                        return 1;
                    default:
                        return 0;
                }
            case Attribute.Water:
                switch (defenderAttribute)
                {
                    case Attribute.Water:
                    case Attribute.Nature:
                        return -1;
                    case Attribute.Fire:
                        return 1;
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }
}
