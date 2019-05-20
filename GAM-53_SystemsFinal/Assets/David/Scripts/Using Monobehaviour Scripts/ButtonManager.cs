using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NUnit.Framework;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[TestFixture]
//[UnityTestAttribute]
public class ButtonManager : MonoBehaviour
{
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
        
    }
    public void CreateNew()
    {
        creatingCreaturePanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LoadData()
    {

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
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        listOfCreatures.SetActive(false);
        creatingCreaturePanel.SetActive(false);
    }

}
