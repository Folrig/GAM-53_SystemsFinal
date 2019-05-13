using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;


public class CreateCreature 
{
    
    private string creatureName;

    private int skill;

    [Test]
    public void Start (string newName, int newSkill)
    {
        creatureName = newName;
        skill = newSkill;
    }
    //[Test]

   /* public void BuiltCreature(string newName, int newSkill)
    {
        

        creatureName = newName;
        skill = newSkill;

        Assert.That(true);
    }*/

}
