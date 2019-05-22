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

    [TestCase(5000, 100)]
    [TestCase(10, 60)]
    [TestCase(-10, 40)]
    [TestCase(-5000, 0)]
    public void AdjustHealthCannotReturnInvalidAmounts_Int(int deltaHealth, int expectedHealth)
    {
        //Arrange
        // Test creature with 50 current / 100 max health
        BattleCreature testCreature = new BattleCreature("TestCreature", Attribute.Fire, 100, 50, 100, 100);

        // Act
        testCreature.AdjustHealth(deltaHealth);

        //Assert
        Assert.That(testCreature.Health, Is.EqualTo(expectedHealth));
    }

    [TestCase(500.251f, 100)]
    [TestCase(9.995f, 60)]
    [TestCase(-9.995f, 40)]
    [TestCase(-500.251f, 0)]
    public void AdjustHealthCannotReturnInvalidAmounts_Float(float deltaHealth, int expectedHealth)
    {
        //Arrange
        // Test creature with 50 current / 100 max health
        BattleCreature testCreature = new BattleCreature("TestCreature", Attribute.Fire, 100, 50, 100, 100);

        // Act
        testCreature.AdjustHealth(deltaHealth);

        //Assert
        Assert.That(testCreature.Health, Is.EqualTo(expectedHealth));
    }

    // This also tests LevelUp() and NextLevelXP()
    [TestCase(150, 1, 50, 2)]
    [TestCase(200, 2, 50, 3)]
    [TestCase(-50, 1, 0, 1)]
    [TestCase(500, 1, 100, 4)]
    [TestCase(1025, 2, 125, 7)]
    public void XPGainsAppropriateAmounts(int gainedXP, int currentLevel, int expectedXP, int expectedLevel)
    {
        //Arrange
        // Test creature with 50 current / 100 max health
        BattleCreature testCreature = new BattleCreature("TestCreature", Attribute.Fire, 100, 50, 100, 100);
        testCreature.Level = currentLevel;

        // Act
        testCreature.GainXP(gainedXP);

        //Assert
        Assert.That(testCreature.CurrentXP, Is.EqualTo(expectedXP));
        Assert.That(testCreature.Level, Is.EqualTo(expectedLevel));
    }
}
