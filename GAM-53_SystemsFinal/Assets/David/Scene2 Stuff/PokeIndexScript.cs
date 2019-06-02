using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeIndexScript : MonoBehaviour
{
    public string[] CreatureIndex;
    [SerializeField]
    private int creatureNum = 0;
    public GameObject ownCreatureData;
    public List<BattleCreature> creature;
    void Start()
    {
        List<BattleCreature> creature = new List<BattleCreature>();
        // David, I really wish you would fix your code errors before pushing a commit.
        // Code errors stop anybody from playtesting anything until your errors are fixed.
        //CreatureIndex = new creature;
        //CreatureIndex = new List<BattleCreature>();

        //creature.Add(new BattleCreature("Creature1", water, 100, 100, 50, 50));
        //creature.Add(new BattleCreature("Creature2", fire, 80, 80, 45, 65));

    }

    void Update()
    {
        for (int i = 0; i < CreatureIndex.Length; i++)
        {
            if ( i == creatureNum)
            {
               // Debug.Log(CreatureIndex[i]);
            }
        }
    }

    public void PickingCreature(int index)
    {
        creatureNum = index;
    }

    //public void 


}
