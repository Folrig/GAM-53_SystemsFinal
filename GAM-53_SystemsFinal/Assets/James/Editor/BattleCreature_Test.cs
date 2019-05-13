using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NUnit;
using NUnit.Framework;

[TestFixture]
[TestOf("BattleCreature")]
public class BattleCreature_Test
{
    [Test]
    public void CreatureBeginsWithMaxHealthTest()
    {
        // Arrange and Act
        const int maxHealth = 100;
        BattleCreature testCreature = new BattleCreature("TestCreature", Attribute.Fire, 100, 120, 100, 100);

        // Assert
        Assert.That(testCreature.MaxHealth, Is.EqualTo(maxHealth));
    }

    [TestCase(5000,100)]
    [TestCase(10,60)]
    [TestCase(-10,40)]
    [TestCase(-5000,0)]
    // Need TestCase for floating point numbers
    public void AdjustHealthCannotReturnInvalidAmounts(int deltaHealth, int expectedHealth)
    {
        //Arrange
        // Test creature with 50 current / 100 max health
        BattleCreature testCreature = new BattleCreature("TestCreature", Attribute.Fire, 100, 50, 100, 100);

        // Act
        testCreature.AdjustHealth(deltaHealth);

        //Assert
        Assert.That(testCreature.Health, Is.EqualTo(expectedHealth));
    }
}
