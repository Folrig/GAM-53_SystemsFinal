using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;

[TestFixture]
public class CreateCreature 
{
    private int creatureHealth = 10;

    private string creatureName;

    private int skill;

    [Test]
    public void CreatingCreatureStats (string newName, int newSkill, int newHealth)
    {
        

        creatureName = newName;
        skill = newSkill;
        creatureHealth = newHealth;

        Assert.That(creatureName, Is.EqualTo(newName));

    }
    //[Test]

   /* public void BuiltCreature(string newName, int newSkill)
    {
        

        creatureName = newName;
        skill = newSkill;

        Assert.That(true);
    }*/

}
