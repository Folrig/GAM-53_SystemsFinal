using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NUnit.Framework;
using System;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

//[TestFixture]
//[UnityTestAttribute]
public class ButtonManager : MonoBehaviour
{
    private PokeMawnDexMainScript pokeMainScript;
    //private BattleCreature battleCreatureStats;
    private PlayerPrefs game;
    [SerializeField]
    private Text nameOfCreature;
    [SerializeField]
    private Text healthOfCreature;

    [SerializeField]
    private Button firePower;
    [SerializeField]
    private Button waterPower;
    [SerializeField]
    private Button earthPower;
    [SerializeField]
    private Button goBack;

    [SerializeField]
    private GameObject listOfCreatures;

    [SerializeField]
    private Text powerText;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private GameObject creatingCreaturePanel;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject savingButton;
    [SerializeField]
    private GameObject loadingDataButton;
    [SerializeField]
    private GameObject deleteButton;
    [SerializeField]
    private GameObject createButton;
    [SerializeField]
    private GameObject creature1;
    [SerializeField]
    private List<PlayerPrefs> BattleCreatures;
    //[SerializeField]
    // private GameObject [] deletes;

    // Use this for initialization
    void Start()
    {
        powerText.text = ("Power: ");
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void Awake()
	{
        
	}

	public void Delete1()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("DavidTestingScene");
    }
    public void SaveGame()
    {
        
    }
    public void SaveCreature()
    {
        /*FileStream file = new FileStream(Application.persistentDataPath + "/Creature.dat", FileMode.OpenOrCreate);
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, game);*/
       // formatter.Serialize(file, this.battleCreatureStats);

        GetComponent<PokeMawnDexMainScript>().creature = new CreatureData2();  //would this work? ... maybe..?
    }
    public void CreateNew()
    {
        creatingCreaturePanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LoadData()
    {
        creature1.SetActive(true);

    }

    public void FirePowerUp()
    {
        powerText.text = ("Power: " + ("Fire"));
    }
    public void WaterPowerUp()
    {
        powerText.text = ("Power: " + ("Water"));
    }
    public void EarthPowerUp()
    {
        powerText.text = ("Power: " + ("Earth"));

    }
    public void ShowListOfCreatures()
    {
        listOfCreatures.SetActive(true);
        mainMenu.SetActive(false);
        creature1.SetActive(false);
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        listOfCreatures.SetActive(false);
        creatingCreaturePanel.SetActive(false);
        creature1.SetActive(false);
    }
    public void CloseWindow()
    {
        creature1.SetActive(false);
        listOfCreatures.SetActive(true);
    }

}
