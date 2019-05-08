using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;


public class TestPokemawndex
{
    private List<CreatureBattle> Battle;
    private string creatureName;
    private int skill;


	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    public void Creature(string newName, int newSkill)
    {
        creatureName = newName;
        skill = newSkill;
    }
}
