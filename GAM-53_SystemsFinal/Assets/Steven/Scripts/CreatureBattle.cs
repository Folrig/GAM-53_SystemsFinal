using System.Collections;
using UnityEngine;

public class CreatureBattle : MonoBehaviour 
{
    public BattleCreature playerCreature;
    private BattleCreature enemyCreature;

    public IEnumerator DoAttack(BattleMove attack)
    {
        yield return null;
    }

    private void ShowMessage(string message)
    {
        
    }

    private IEnumerator DoEnemyTurn()
    {
        yield return null;
    }

    private void FinishBattle()
    {
        
    }

    private BattleCreature GenerateEnemy(int level)
    {
        return null;
    }
}
