using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit;
using NUnit.Framework;

[TestFixture]
[TestOf("CreaturePanels")]
public class CreaturePanels_Test
{
    public Text playerName;
    public Text playerHP;
    public Image playerBar;
    public Text enemyName;
    public Image enemyBar;
    public CreaturePanels panelManager;

    [OneTimeSetUp]
    public void Setup()
    {
        GameObject parent = new GameObject("Test", typeof(Canvas));
        panelManager = parent.AddComponent<CreaturePanels>();
        GameObject child1 = new GameObject("Test");
        playerName = child1.AddComponent<Text>();
        GameObject child2 = new GameObject("Test");
        playerHP = child2.AddComponent<Text>();
        GameObject child3 = new GameObject("Test");
        playerBar = child3.AddComponent<Image>();
        playerBar.type = Image.Type.Filled;
        playerBar.fillMethod = Image.FillMethod.Horizontal;
        GameObject child4 = new GameObject("Test");
        enemyName = child4.AddComponent<Text>();
        GameObject child5 = new GameObject("Test");
        enemyBar = child5.AddComponent<Image>();
        enemyBar.type = Image.Type.Filled;
        enemyBar.fillMethod = Image.FillMethod.Horizontal;

        panelManager.TestInit(playerName, playerHP, playerBar, enemyName, enemyBar);
    }

    [TestCase("")]
    [TestCase("Stuff and things")]
    [TestCase("...\n\n\n\n\n\n...\n\n\n...")]
    [TestCase(null)]
    public void PlayerUpdate_UpdatesName(string name)
    {
        BattleCreature bc = new BattleCreature(name, Attribute.Fire, 1, 1, 1, 1);
        
        panelManager.UpdatePlayer(bc);

        Assert.AreEqual(name, playerName.text);
    }

    [TestCase(100,100)]
    [TestCase(200,100)]
    [TestCase(0,100)]
    [TestCase(1,2)]
    [TestCase(-25,100)]
    [TestCase(100,-25)]
    [TestCase(0,0)]
    [TestCase(100,int.MaxValue)]
    [TestCase(int.MaxValue,100)]
    public void PlayerUpdate_UpdatesHealthNumbers(int min, int max)
    {
        BattleCreature bc = new BattleCreature("Name", Attribute.Fire, max, min, 1, 1);
        // Exclude unexpected constraints from the BattleCreature class
        if (bc.Health != min)
        {
            min = bc.Health;
        }
        if (bc.MaxHealth != max)
        {
            max = bc.MaxHealth;
        }

        panelManager.UpdatePlayer(bc);

        string testString = min.ToString() + " / " + max.ToString();        
        Assert.AreEqual(testString, playerName.text);
    }

    [TestCase(100, 100)]
    [TestCase(200, 100)]
    [TestCase(0, 100)]
    [TestCase(1, 2)]
    [TestCase(-25, 100)]
    [TestCase(100, -25)]
    [TestCase(0, 0)]
    [TestCase(100, int.MaxValue)]
    [TestCase(int.MaxValue, 100)]
    public void PlayerUpdate_BarReflectsHealthPercentage(int min, int max)
    {
        BattleCreature bc = new BattleCreature("Name", Attribute.Fire, max, min, 1, 1);
        // Exclude unexpected constraints from the BattleCreature class
        if (bc.Health != min)
        {
            min = bc.Health;
        }
        if (bc.MaxHealth != max)
        {
            max = bc.MaxHealth;
        }

        if (max == 0)
        {
            Assert.Throws<System.DivideByZeroException>(() => panelManager.UpdatePlayer(bc, true));
            return;
        }
        else
        {
            panelManager.UpdatePlayer(bc);
        }

        float expected = (float)min / (float)max;
        Assert.AreEqual(expected, playerBar.fillAmount);
    }

    [TestCase("")]
    [TestCase("Stuff and things")]
    [TestCase("...\n\n\n\n\n\n...\n\n\n...")]
    [TestCase(null)]
    public void EnemyUpdate_UpdatesName(string name)
    {
        BattleCreature bc = new BattleCreature(name, Attribute.Fire, 1, 1, 1, 1);

        panelManager.UpdateEnemy(bc);

        Assert.AreEqual(name, enemyName.text);
    }

    [TestCase(100, 100)]
    [TestCase(200, 100)]
    [TestCase(0, 100)]
    [TestCase(1, 2)]
    [TestCase(-25, 100)]
    [TestCase(100, -25)]
    [TestCase(0, 0)]
    [TestCase(100, int.MaxValue)]
    [TestCase(int.MaxValue, 100)]
    public void EnemyUpdate_BarReflectsHealthPercentage(int min, int max)
    {
        BattleCreature bc = new BattleCreature("Name", Attribute.Fire, max, min, 1, 1);
        // Exclude unexpected constraints from the BattleCreature class
        if (bc.Health != min)
        {
            min = bc.Health;
        }
        if (bc.MaxHealth != max)
        {
            max = bc.MaxHealth;
        }

        if (max == 0)
        {
            Assert.Throws<System.DivideByZeroException>(() => panelManager.UpdateEnemy(bc, true));
            return;
        }
        else
        {
            panelManager.UpdateEnemy(bc);
        }

        float expected = (float)min / (float)max;
        Assert.AreEqual(expected, enemyBar.fillAmount);
    }
}
