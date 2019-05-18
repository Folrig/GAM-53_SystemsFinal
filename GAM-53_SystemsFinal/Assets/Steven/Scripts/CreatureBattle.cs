using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreatureBattle : MonoBehaviour 
{
    public BattleCreature playerCreature;
    private BattleCreature enemyCreature;

    private PlayerController playerController;
    private EnemyController enemyController;
    private GameObject playerAvatar;
    private GameObject enemyAvatar;

    // These should be set in the inspector as a prefab
    [SerializeField] private GameObject CBUI;
    [SerializeField] private MessageList messageList;
    [SerializeField] private Transform playerAvatarPosition;
    [SerializeField] private Transform enemyAvatarPosition;
    [SerializeField] private Text playerName;
    [SerializeField] private Text playerHealth;
    [SerializeField] private Text enemyName;
    [SerializeField] private Image playerGauge;
    [SerializeField] private Image enemyGauge;

    private bool playersTurn = false;

	private void Start()
	{
        
	}

    public void TurnDone(BattleMove attack, int strength)
    {
        
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

    private void FinishBattle()
    {
        
    }

    private BattleCreature GenerateEnemy(int level)
    {
        return null;
    }
}
