using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PokeIndexScript : MonoBehaviour
{
    public BattleCreature[] CreatureIndex;
    [SerializeField]
    private int creatureNum = 0;
    public GameObject ownCreatureData;
    public List<BattleCreature> creature;
    public AddingToGrid gridScript;
    public GameObject GridView;
    [SerializeField]
    private int howMany;

   // public CreatureBattle battleSystem;


    [SerializeField]
    private GameObject spaceHolder;

    void Start()
    {

        //CreatureBattle battleSystem = new CreatureBattle();




        gridScript = GridView.GetComponent<AddingToGrid>();
        howMany = 0;


        List<BattleCreature> creature = new List<BattleCreature>();

       /* CreatureIndex = new creature;
        CreatureIndex = new List<BattleCreature>();

        creature.Add(new BattleCreature("Creature1", water, 100, 100, 50, 50));
        creature.Add(new BattleCreature("Creature2", fire, 80, 80, 45, 65));
*/
    }

    void Update()
    {
        // gridScript.CreaturesAddToGrid();

        /* GameObject newObj;

         for (int i = 0; i < CreatureIndex.Length; i++)
         {
             if ( i == creatureNum)
             {
                 newObj = (GameObject)Instantiate(spaceHolder, transform);

                // Debug.Log(CreatureIndex[i]);
             }
         }*/

        for (int i = 0; i < creature.Count; i++)
        {
        }

    }

    public void PickingCreature(int index)
    {
        creatureNum = index;
    }

    public void AddingNewImage()
    {
        gridScript.CreaturesAddToGrid();
        gridScript.AddANewCreature();
        NewCreatureData();
    }

	public void OnMouseUp()
	{
        gridScript.AddingIsFalse();

	}
    public void OnMouseDown()
    {
        Debug.Log(spaceHolder.name + creature);
    }

    public void NewCreatureData()
    {
        foreach (BattleCreature creation in CreatureIndex)
        {
             howMany += 1;

        }

    }

    public void GoingBackToMenu()
    {
        SceneManager.LoadScene("DavidTestingScene");
    }



}
