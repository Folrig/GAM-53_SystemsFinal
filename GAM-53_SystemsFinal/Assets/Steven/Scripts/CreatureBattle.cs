using System;
using System.Collections;
using UnityEngine;

public class CreatureBattle : MonoBehaviour 
{
    public BattleCreature playerCreature;
    private BattleCreature enemyCreature;

    private PlayerController playerController;
    private EnemyController enemyController;
    private GameObject playerAvatar;
    private GameObject enemyAvatar;

    // These should be set from the CBUI prefab
    [SerializeField] private GameObject CBUI;
    [SerializeField] private MessageList messageList;
    [SerializeField] private CommandPanel commandPanel;
    [SerializeField] private CreaturePanels creaturePanels;

    // These need to be set externally
    [SerializeField] private Transform playerAvatarPosition;
    [SerializeField] private Transform enemyAvatarPosition;

    private bool playersTurn = false;
    [SerializeField] private float messageWaitTime = 3.0f;

    private static readonly string[] genNames = { "Spot", "Fluffy", "Spike", "Fido", "Mittens", "Rex", "Princess", "Buddy", "Bear", "Duke" };

	private void Start()
	{
        
	}

    private void OnEnable()
    {
        commandPanel.CommandClick += PlayerCommandClicked;
    }

    private void OnDisable()
    {
        commandPanel.CommandClick -= PlayerCommandClicked;
    }

    public void SendAttack(BattleMove attack, int strength)
    {
        if (playersTurn)
        {
            AttackResult enemyResult = enemyController.ReceiveAttack(attack, strength);
            commandPanel.TogglePanel(false);
            StartCoroutine(ShowAttackResult(enemyCreature, playerCreature, enemyResult));
        }
        else
        {
            AttackResult playerResult = playerController.ReceiveAttack(attack, strength);
            StartCoroutine(ShowAttackResult(playerCreature, enemyCreature, playerResult));
        }
    }

	public IEnumerator DoAttack(BattleMove attack)
    {
        yield return null;
    }

    private void ShowMessage(string message)
    {
        messageList.AddMessage(message);
    }

    private IEnumerator DoEnemyTurn()
    {
        yield return null;
    }

    private IEnumerator FinishBattle()
    {
        if (playerCreature.IsFainted)
        {
            yield return StartCoroutine(MessageWithDelay("Your Pokemawn has been defeated."));
        }
        else
        {
            yield return StartCoroutine(MessageWithDelay("Your Pokemawn is victorious!"));
            int toNextLevel = playerCreature.NextLevelXP();
            // Need access to creature level to determine how much XP to generate
            int fightXP = CalculateXP(1);
            yield return StartCoroutine(MessageWithDelay(playerCreature.Name + " receives " + fightXP + " XP from the fight."));
            playerCreature.GainXP(fightXP);
            if (fightXP > toNextLevel)
            {
                yield return StartCoroutine(MessageWithDelay(playerCreature.Name + " gained a level!"));
            }
        }
        Destroy(CBUI);
    }

    private BattleCreature GenerateEnemy(int desiredLevel)
    {
        string name = genNames[UnityEngine.Random.Range(0, genNames.Length)];
        Array attribValues = Enum.GetValues(typeof(Attribute));
        Attribute attrib = (Attribute)attribValues.GetValue(UnityEngine.Random.Range(0, attribValues.Length));
        int health = UnityEngine.Random.Range(80, 121);
        int power = UnityEngine.Random.Range(1, 100);
        int agility = 100 - power;

        BattleCreature newCreature = new BattleCreature(name, attrib, health, health, power, agility);

        int level = 1;
        while (level < desiredLevel)
        {
            newCreature.GainXP(newCreature.NextLevelXP());
            level++;
        }

        return newCreature;
    }

    private void PlayerCommandClicked(string command)
    {
        playerController.CommandInput(command);
    }

    private IEnumerator ShowAttackResult(BattleCreature attacker, BattleCreature defender, AttackResult result)
    {
        if (result.isDodged)
        {
            yield return StartCoroutine(MessageWithDelay(defender.Name + " deftly evades harm!"));
        }
        else
        {
            if (result.isStrong)
            {
                yield return StartCoroutine(MessageWithDelay(defender.Name + " finds itelf vulnerable to the attack!"));
            }
            else if (result.isWeak)
            {
                yield return StartCoroutine(MessageWithDelay(defender.Name + " defiantly resists the attack!"));
            }

            if (defender == playerCreature)
            {
                creaturePanels.UpdatePlayer(defender);
            }
            else
            {
                creaturePanels.UpdateEnemy(defender);
            }
            yield return StartCoroutine(MessageWithDelay(defender.Name + " receives " + result.damageTaken + " damage."));

            if (defender.IsFainted)
            {
                yield return StartCoroutine(MessageWithDelay(defender.Name + " falls over and faints!"));
                yield return StartCoroutine(FinishBattle());
            }
            else
            {
                playersTurn = !playersTurn;
                if (playersTurn)
                {
                    ShowMessage("Command?");
                    playerController.GetAttack();
                }
                else
                {
                    enemyController.GetAttack();
                }
            }
        }
    }

    private IEnumerator MessageWithDelay(string message)
    {
        ShowMessage(message);
        yield return new WaitForSeconds(messageWaitTime);
    }

    private int CalculateXP(int fightLevel)
    {
        // Arbitrary XP award formula, can be easily changed to something else
        return 25 * fightLevel;
    }
}
