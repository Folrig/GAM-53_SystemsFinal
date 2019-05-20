using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;


namespace PokeMawnDéx.EditorTest
{
    [TestFixture]
    public class PokeMawnDexTesting
    {
        //data from a creature that hasn't battled
        [Test]
        public void CreatureDataBy_UserIsCreature_ReturnsTrue()
        {

            //Arrange
            var creatureData = new CreatureData();
            //Act
            var result = creatureData.CreatureDataBy(new User { IsCreature = true });
            var result2 = creatureData.CreatureDataBy(new User { IsBattleCreature = true });
            //Assert
            Assert.IsTrue(result);
            Assert.IsTrue(result2);


        }
        //data from a creature that has battled
        [Test]
        public void CreatureDataBy_UserIsBattleCreature_ReturnsTrue()
        {
            //Arrange
            var creatureData = new CreatureData();
            //Act

            var result = creatureData.CreatureDataBy(new User { IsBattleCreature = true });
            //Assert

            Assert.IsTrue(result);
        }
        //new creatures data
        [Test]
        public void CreatureDataBy_SameCreatureName_ReturnsTrue()
        {
            //Arrange
            var name = new User();
            var creatureData = new CreatureData{CreatureName = name};
            //Act
            var result = creatureData.CreatureDataBy(name);
            //Assert
            Assert.IsTrue(result);
        }
        //if current creature is selected then it cant open another creatures data.... 
        [Test]
        public void CreatureDataBy_OtherCreatureNameData_ReturnsFalse()
        {
            //Arrange
            var creatureData = new CreatureData{CreatureName = new User()};
            //Act
            var result = creatureData.CreatureDataBy(new User());
             //Assert
            Assert.IsFalse(result);  
        }

        //a creature that was once created could be customized
        [Test]
        public void CanBeCustomizedBy_UserIsCreature_ReturnsTrue()
        {

            //Arrange
            var customization = new Customization();
            //Act
            var result = customization.CreatureCustomize(new User { IsCreature = true });
            //Assert
            Assert.IsTrue(result);
        }
        //new creature that can be customized
        [Test]
        public void CanBeCustomizedBy_CustomizeableCreature_ReturnsTrue()
        {
            //Arrange
            var customizeablename = new User();
            var customization = new Customization { Customizeable = customizeablename };
            //Act
            var result = customization.CreatureCustomize(customizeablename);
            //Assert
            Assert.IsTrue(result);
        }
        //If creature from battle wants to be customized again then it cant... (this could be changed / or deleted...)
        [Test]
        public void CanBeCustomizedBy_OtherCreatureNameData_ReturnsFalse()
        {
            //Arrange
            var customization = new Customization { Customizeable = new User() };
            //Act
            var result = customization.CreatureCustomize(new User());
            //Assert
            Assert.IsFalse(result);
        }
        //Saving whole Game
        [Test]
        public void SavingBy_SavingGame_ReturnsTrue()
        {
            //Arrange
            var saving = new SavingGame();
            //Act
           var result = saving.GameSaving(new GameSaver { IsGameSaved = true });
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void SavingBy_SavingBattleGame_ReturnsTrue()
        {
            //Arrange
            var saving = new SavingGame();
            //Act
            var result = saving.GameSaving(new GameSaver { IsBattleSaved = true });
            //Assert
            Assert.IsTrue(result);
        }

    }

   

}


                   
