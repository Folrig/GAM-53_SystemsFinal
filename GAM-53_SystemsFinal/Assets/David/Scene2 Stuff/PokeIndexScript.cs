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
        CreatureIndex = new creature;
        CreatureIndex = new List<BattleCreature>();

        creature.Add(new BattleCreature("Creature1", water, 100, 100, 50, 50));
        creature.Add(new BattleCreature("Creature2", fire, 80, 80, 45, 65));

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

    public void 


}
