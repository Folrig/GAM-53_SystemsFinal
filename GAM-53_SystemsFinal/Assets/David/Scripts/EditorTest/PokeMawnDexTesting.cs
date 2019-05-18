using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;


namespace UnitTesting.EditorTest
{
    [TestFixture]
    public class PokeMawnDexTesting
    {
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
    }
}
