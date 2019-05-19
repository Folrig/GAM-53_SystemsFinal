public class EnemyController : CreatureController
{
    public EnemyController(BattleCreature creature, CreatureBattle battleController) : base(creature, battleController) { }

    public override void GetAttack()
    {
        BattleMove chosenMove = creature.moves[UnityEngine.Random.Range(0, creature.moves.Count)];
        /* Need access to BattleCreature power and agility for this to work
         int strength;

        if (move.usesPower)
        {
            strength = creature.power;
        }
        else
        {
            strength = creature.agility;
        }

        battleController.SendAttack(chosenMove, strength);
        */
    }
}
