abstract public class CreatureController
{
    public readonly BattleCreature creature;
    protected CreatureBattle battleController;

    public CreatureController(BattleCreature creature, CreatureBattle battleController)
    {
        if (creature == null)
            throw new System.Exception("Creature of a CreatureController cannot be null.");
        if (battleController = null)
            throw new System.Exception("Battle Controller of a CreatureController cannot be null.");
        
        this.creature = creature;
        this.battleController = battleController;
    }

    public AttackResult ReceiveAttack(BattleMove attack, int strength)
    {
        // Need access to creature's attribute for below line to work
        //int damage = strength * (1 - 0.25 * CompareAttributes(attack.attribute, creature.attribute));
        int damage = strength;

        return creature.ReceiveAttack(damage, attack);
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
