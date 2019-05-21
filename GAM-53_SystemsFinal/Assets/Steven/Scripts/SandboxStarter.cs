using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandboxStarter : MonoBehaviour 
{
    [SerializeField] private Transform canvas;
    [SerializeField] private GameObject battleUIPrefab;
    [SerializeField] private string creatureName;
    [SerializeField] private Attribute attribute;
    [SerializeField] private int hp = 100;
    [SerializeField] private int power = 40;
    [SerializeField] private int agility = 60;

    [SerializeField] private string moveName1;
    [SerializeField] private Attribute moveAttrib1;
    [SerializeField] private bool usesPower1;

    [SerializeField] private string moveName2;
    [SerializeField] private Attribute moveAttrib2;
    [SerializeField] private bool usesPower2;

	// Use this for initialization
	void Start () 
    {
        BattleCreature battleCreature = new BattleCreature(creatureName, attribute, hp, hp, power, agility);
        BattleMove move1 = new BattleMove();
        move1.name = moveName1;
        move1.attribute = moveAttrib1;
        move1.usesPower = usesPower1;
        battleCreature.moves.Add(move1);
        BattleMove move2 = new BattleMove();
        move2.name = moveName2;
        move2.attribute = moveAttrib2;
        move2.usesPower = usesPower2;
        battleCreature.moves.Add(move2);
        GameObject cbui = Instantiate(battleUIPrefab, canvas, false);
        CreatureBattle creatureBattle = cbui.GetComponent<CreatureBattle>();
        creatureBattle.Initialize(battleCreature, null, null);
	}
}
