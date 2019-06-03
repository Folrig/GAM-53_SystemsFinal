using UnityEngine;
using System.IO;

public class SandboxStarter : MonoBehaviour 
{
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject battleUIPrefab;
    [SerializeField] private CreatureCreator creator;

    [SerializeField] private string fileName = "CreatureData";

    private BattleCreature creature;

	// Use this for initialization
	private void Start () 
    {
        if (File.Exists("Assets/Data/" + fileName + ".json"))
        {
            creature = new BattleCreature();
            DataController.LoadGameData(fileName, creature);
            StartBattle();
        }
        else
        {
            creator.CreationFinished += CreatureCreated;
            creator.StartCreator();
        }
	}

    private void CreatureCreated(BattleCreature newCreature)
    {
        creature = newCreature;
        DataController.SaveData(fileName, creature);
        StartBattle();
    }

    private void BattleFinished()
    {
        DataController.SaveData(fileName, creature);
    }

    private void StartBattle()
    {
        GameObject cbui = Instantiate(battleUIPrefab, canvas, false);
        CreatureBattle creatureBattle = cbui.GetComponent<CreatureBattle>();
        creatureBattle.BattleFinished += BattleFinished;
        creatureBattle.Initialize(creature);        
    }
}
