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
    [SerializeField]
    private GameObject [] deletes;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void Delete()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("DavidTestingScene");
    }
    public void SaveGame()
    {

    }
    public void CreateNew()
    {

    }
    public void LoadData()
    {

    }


}
