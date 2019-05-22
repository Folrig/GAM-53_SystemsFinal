using UnityEngine;
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
        
        BattleMove chosenMove = new BattleMove { name = "BadMove", usesPower = false, attribute = Attribute.Fire };
        bool moveFound = false;
        foreach (BattleMove move in creature.moves)
        {
            if (move.name == command)
            {
                chosenMove = move;
                moveFound = true;
                break;
            }
        }
        if (!moveFound)
        {
            throw new UnityException("Cannot find command that was clicked on!");
        }

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
