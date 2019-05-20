using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;

//[TestFixture]
public class PokemawnDex 
{
    
    public List<LoadingData> loadData = new List<LoadingData>();

   // [Test]
    public  void CreateCreature()
    {
        Assert.That(true); 

    }

   // [Test]
    public void Saving()
    {
        Assert.That(true);
    }

    //[Test]
    public void Load(LoadingData loading)
    {
        if (loadData != null)
        {
            Assert.That(true);
        }
        Assert.That(true);
    }

    //[Test]
    public void TestingPokeValues ()
    {
        
        CreateCreature creatureStats = new CreateCreature();


        Assert.That(true);

    }
	
}
