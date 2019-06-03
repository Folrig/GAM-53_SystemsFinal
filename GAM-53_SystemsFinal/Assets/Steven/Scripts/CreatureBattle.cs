﻿using System;
using System.Collections;
using UnityEngine;

public class CreatureBattle : MonoBehaviour 
{
    public BattleCreature playerCreature;
    private BattleCreature enemyCreature;

    private PlayerController playerController;
    private EnemyController enemyController;

    // These should be set from the CBUI prefab
    [SerializeField] private GameObject CBUI;
    [SerializeField] private MessageList messageList;
    [SerializeField] private CommandPanel commandPanel;
    [SerializeField] private CreaturePanels creaturePanels;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject enemyObject;

    // These need to be set externally
    [SerializeField] private Transform playerAvatarPosition;
    [SerializeField] private Transform enemyAvatarPosition;

    private GameObject playerAvatar;
    private GameObject enemyAvatar;
    private Animator playerAnimator;
    private Animator enemyAnimator;

    public bool playersTurn = false;
    [SerializeField] private float messageWaitTime = 3.0f;

    private static readonly string[] genCreatureNames = { "Spot", "Fluffy", "Spike", "Fido", "Mittens", "Rex", "Princess", "Buddy", "Bear", "Duke" };
    private static readonly string[] genMoveNames = { "Crusher", "Whiplash", "Inferno", "Bladespin", "Deluge" };

    private void OnEnable()
    {
        commandPanel.CommandClick += PlayerCommandClicked;
    }

    private void OnDisable()
    {
        commandPanel.CommandClick -= PlayerCommandClicked;
    }

    public void Initialize(BattleCreature playerCreature)
    {
        //this.playerAvatarPosition = playerAvatarPosition;
        //this.enemyAvatarPosition = enemyAvatarPosition;

        this.playerCreature = playerCreature;
        int lowLevelBound = playerCreature.Level - 2;        
        int highLevelBound = playerCreature.Level + 2;
        int enemyLevel = UnityEngine.Random.Range(lowLevelBound, highLevelBound + 1);
        if (enemyLevel < 1)
        {
            enemyLevel = 1;
        }
        enemyCreature = GenerateEnemy(enemyLevel);

        // I lack access to the avatars to instantiate them
        // playerAvatar = Instantiate(playerCreature.Avatar, playerAvatarPosition);
        // enemyAvatar = Instantiate(enemyCreature.Avatar, enemyAvatarPosition);
        // playerAnimator = playerAvatar.GetComponent<Animator>();
        // if (playerAnimator == null)
        // {
        //     Debug.LogWarning("[F" + Time.frameCount + "] Player avatar does not have an Animator.");
        // }
        // enemyAnimator = enemyAvatar.GetComponent<Animator>();
        // if (enemyAnimator == null)
        // {
        //     Debug.LogWarning("[F" + Time.frameCount + "] Enemy avatar does not have an Animator.");
        // }

        playerController = new PlayerController(playerCreature, this, commandPanel);
        enemyController = new EnemyController(enemyCreature, this);

        creaturePanels.UpdatePlayer(playerCreature, true);
        creaturePanels.UpdateEnemy(enemyCreature, true);

        playersTurn = RandomBool();
        StartCoroutine(BattleIntro());
    }

    private IEnumerator BattleIntro()
    {
        yield return StartCoroutine(MessageWithDelay("A wild " + enemyCreature.Name + " appears!"));
        if (playersTurn)
        {
            yield return StartCoroutine(MessageWithDelay("Command?"));
        }

        (playersTurn ? (CreatureController)playerController : (CreatureController)enemyController).GetAttack();
    }

    public void SendAttack(BattleMove attack, int strength)
    {
        if (playersTurn)
        {
            AttackResult enemyResult = enemyController.ReceiveAttack(attack, strength, playerCreature.Agility);
            commandPanel.TogglePanel(false);
            StartCoroutine(ShowAttackResult(playerCreature, enemyCreature, attack.name, enemyResult));
        }
        else
        {
            AttackResult playerResult = playerController.ReceiveAttack(attack, strength, enemyCreature.Agility);
            StartCoroutine(ShowAttackResult(enemyCreature, playerCreature, attack.name, playerResult));
        }
    }

    private IEnumerator ShowAttackResult(BattleCreature attacker, BattleCreature defender, string attackName, AttackResult result)
    {
        yield return StartCoroutine(MessageWithDelay(attacker.Name + " uses " + attackName + "!"));

        // Animation coroutine call here

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
                yield break;
            }
        }
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
            int fightXP = CalculateXP(enemyCreature.Level);
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
        string name = genCreatureNames[UnityEngine.Random.Range(0, genCreatureNames.Length)];
        Attribute attrib = RandomAttribute();
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

        int movesToCreate = UnityEngine.Random.Range(1, 5);
        for (int i = 1; i <= movesToCreate; i++)
        {
            BattleMove move = new BattleMove();
            move.attribute = RandomAttribute();
            move.usesPower = RandomBool();
            move.name = genMoveNames[UnityEngine.Random.Range(0, genMoveNames.Length)];
            newCreature.moves.Add(move);
        }

        return newCreature;
    }

    private Attribute RandomAttribute()
    {
        Array attribValues = Enum.GetValues(typeof(Attribute));
        Attribute attrib = (Attribute)attribValues.GetValue(UnityEngine.Random.Range(0, attribValues.Length));
        return attrib;
    }

    private bool RandomBool()
    {
        return UnityEngine.Random.value > 0.5f ? true : false;
    }

    private void PlayerCommandClicked(string command)
    {
        playerController.CommandInput(command);
    }

    private void ShowMessage(string message)
    {
        messageList.AddMessage(message);
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
