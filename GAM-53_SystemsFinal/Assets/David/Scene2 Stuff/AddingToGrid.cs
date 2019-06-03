using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddingToGrid : MonoBehaviour
{
    [SerializeField]
    private GameObject spaceHolder;
    [SerializeField]
    private int howMany;
    
    public bool AddingIsAbailable = false;
    private BattleCreature battleCreature;
    public List<BattleCreature> creature;

    public BattleCreature[] CreatureIndex;




    public void Start()
    {
        AddingIsAbailable = true;


        //battleCreature = new BattleCreature();
        List<BattleCreature> list = new List<BattleCreature>(); 
        creature = new List<BattleCreature>();

        creature = list;
        howMany = 0;

        //AddANewCreature();
        //CreaturesAddToGrid();

    }

	private void Awake()
	{
        //CreaturesAddToGrid();

	}

	void Update()
    {
        //CreaturesAddToGrid();
    }

    public void CreaturesAddToGrid()
    {
        
        GameObject newObj;

        if (AddingIsAbailable == true)
        {
            for (int i = 0; i <= howMany; i++ )  //i = howMany)
            {
                i += 1;
                newObj = (GameObject)Instantiate(spaceHolder, transform);

               

               /* if (i > howMany)
                {
                    newObj = null;
                    //newObj = (GameObject)Instantiate(spaceHolder, transform);
                }*/
            }
        }
        else
        {
            AddingIsAbailable = false;
        }
        /*
        for (int i = 0; i < CreatureIndex.Length; i++)
        {
            if (i==howMany)
            {
                newObj = (GameObject)Instantiate(spaceHolder, transform);
  
            }
        }*/
    }

    public void AddANewCreature()
    {
       // AddingIsAbailable = true;
        howMany += 1;
        creature = new List<BattleCreature>();
       // creature.Add(new BattleCreature("Creature1", Attribute.Water, 100, 100, 50, 50));
       // creature.Add(new BattleCreature());

      //  OnMouseUp();
    }

	public void OnMouseDown()
	{
        Debug.Log(spaceHolder.name);
	}

	/*public void OnMouseUp()
	{
        AddingIsAbailable = false;
	}*/

    public void AddingIsFalse()
    {
       // AddingIsAbailable = false; 
    }
}
