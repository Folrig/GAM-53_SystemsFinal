namespace PokeMawnDéx.EditorTest
{
    public class SavingGame
    {
        public GameSaver GameSaver { get; set; }

        public bool GameSaving(GameSaver gameSaver)
        {
            if (gameSaver.IsGameSaved)
                return true;
            if (gameSaver.IsBattleSaved)
                return true;
            

            return false;
        }
    }

    public class GameSaver
    {
        public bool IsGameSaved { get; set; }
        public bool IsBattleSaved{ get; set; }
    }

   
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit.Framework;

[TestFixture]
public class Saving 
{
    public string creatureName;

    public int skill; 


   // [Test]
   // public static void Save(Skills skills, CreateCreature createCreature)
    //{
        
    //    Assert.That(true);
    //}

    [Test]
    public static void Save()
    {

        Assert.That(true);
    }




    public Saving()
    {
        return;
    }
	
}*/
