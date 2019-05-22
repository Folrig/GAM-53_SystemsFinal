using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CreaturePanels : MonoBehaviour
{
    [SerializeField] private Text playerCreatureName;
    [SerializeField] private Text playerCreatureHealth;
    [SerializeField] private Image playerCreatureBar;

    [SerializeField] private Text enemyCreatureName;
    [SerializeField] private Image enemyCreatureBar;

    [SerializeField] [Range(0.01f, 5.0f)] private float BarSlideTimeInSecs = 1.0f;

    private bool playerBarMoving = false;
    private bool enemyBarMoving = false;

    public void UpdatePlayer(BattleCreature player, bool immediate = false)
    {
        playerCreatureName.text = player.Name;
        playerCreatureHealth.text = player.Health.ToString() + " / " + player.MaxHealth.ToString();
        if (immediate)
        {
            float fillAmount = (float)player.Health / (float)player.MaxHealth;
            if (float.IsNaN(fillAmount))
            {
                fillAmount = 0.0f;
            }
            playerCreatureBar.fillAmount = fillAmount;
        }
        else
        {
            if (playerBarMoving)
            {
                Debug.Log("[F" + Time.frameCount + "] Forced to kill bar animator.");
                StopAllCoroutines();
                playerBarMoving = false;
            }
            float fillAmount = (float)player.Health / (float)player.MaxHealth;
            if (float.IsNaN(fillAmount))
            {
                fillAmount = 0.0f;
            }
            StartCoroutine(AnimateHealthBar(playerCreatureBar, playerCreatureBar.fillAmount, fillAmount, true));
        }
    }

    public void UpdateEnemy(BattleCreature enemy, bool immediate = false)
    {
        enemyCreatureName.text = enemy.Name;
        if (immediate)
        {
            float fillAmount = (float)enemy.Health / (float)enemy.MaxHealth;
            if (float.IsNaN(fillAmount))
            {
                fillAmount = 0.0f;
            }
            enemyCreatureBar.fillAmount = fillAmount;
        }
        else
        {
            if (enemyBarMoving)
            {
                Debug.Log("[F" + Time.frameCount + "] Forced to kill bar animator.");
                StopAllCoroutines();
                enemyBarMoving = false;
            }
            float fillAmount = (float)enemy.Health / (float)enemy.MaxHealth;
            if (float.IsNaN(fillAmount))
            {
                fillAmount = 0.0f;
            }
            StartCoroutine(AnimateHealthBar(enemyCreatureBar, enemyCreatureBar.fillAmount, fillAmount, false));
        }
    }

    private IEnumerator AnimateHealthBar(Image healthBar, float from, float to, bool barIsPlayers)
    {
        if (barIsPlayers)
        {
            playerBarMoving = true;
        }
        else
        {
            enemyBarMoving = true;
        }
        float fillTime = 0.0f;
        while (!Mathf.Approximately(healthBar.fillAmount, to))
        {
            float fillAmount = Mathf.Lerp(from, to, fillTime / BarSlideTimeInSecs);
            if (float.IsNaN(fillAmount))
            {
                fillAmount = 0.0f;
            }
            healthBar.fillAmount = fillAmount;
            fillTime += Time.deltaTime;
            if (fillTime > BarSlideTimeInSecs)
            {
                fillTime = BarSlideTimeInSecs;
            }
            yield return null;
        }
        healthBar.fillAmount = to;
        if (barIsPlayers)
        {
            playerBarMoving = false;
        }
        else
        {
            enemyBarMoving = false;
        }
    }

    public void TestInit(Text pCN, Text pCH, Image pCB, Text eCN, Image eCB)
    {
        playerCreatureName = pCN;
        playerCreatureHealth = pCH;
        playerCreatureBar = pCB;
        enemyCreatureName = eCN;
        enemyCreatureBar = eCB;
    }
}
