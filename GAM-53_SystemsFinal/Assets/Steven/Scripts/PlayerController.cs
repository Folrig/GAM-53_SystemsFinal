public class PlayerController : CreatureController
{
    private CommandPanel panel;
    private bool waitingForInput = false;

    public PlayerController(BattleCreature creature, CreatureBattle battleController, CommandPanel panel) : base(creature, battleController) 
    {
        this.panel = panel;
        foreach (BattleMove move in creature.moves)
        {
            panel.AddCommand(move.name);
        }
        panel.TogglePanel(false);
    }

    public override void GetAttack()
    {
        panel.TogglePanel(true);


        waitingForInput = true;
    }

    public void CommandInput(string command)
    {
        if (!waitingForInput)
            return;

        BattleMove chosenMove;
        chosenMove.name = "";
        foreach (BattleMove move in creature.moves)
        {
            if (move.name == command)
            {
                chosenMove = move;
                break;
            }
        }
        if (chosenMove.name == "")
            return;

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
