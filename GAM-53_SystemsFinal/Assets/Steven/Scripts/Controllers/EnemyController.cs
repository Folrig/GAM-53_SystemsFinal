public class EnemyController : CreatureController
{
    public EnemyController(BattleCreature creature, CreatureBattle battleController) : base(creature, battleController){}

    public override void GetAttack()
    {
        BattleMove chosenMove = creature.moves[UnityEngine.Random.Range(0, creature.moves.Count)];

        int strength;

        if (chosenMove.usesPower)
        {
            strength = creature.Power;
        }
        else
        {
            strength = creature.Agility;
        }
        battleController.SendAttack(chosenMove, strength);
    }
}
