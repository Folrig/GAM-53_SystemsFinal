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

    private void Start()
    {
        playerCreatureName.text = "";
        playerCreatureHealth.text = "0 / 0";
        playerCreatureBar.fillAmount = 1f;

        enemyCreatureName.text = "";
        enemyCreatureBar.fillAmount = 1f;
    }

    public void UpdatePlayer(BattleCreature player, bool immediate = false)
    {
        playerCreatureName.text = player.Name;
        playerCreatureHealth.text = player.Health.ToString() + " / " + player.MaxHealth.ToString();
        if (immediate)
        {
            playerCreatureBar.fillAmount = (float)player.Health / (float)player.MaxHealth;
        }
        else
        {
            if (playerBarMoving)
            {                
                StopAllCoroutines();
                playerBarMoving = false;
            }
            StartCoroutine(AnimateHealthBar(playerCreatureBar, playerCreatureBar.fillAmount, (float)player.Health / (float)player.MaxHealth, true));
        }
    }

    public void UpdateEnemy(BattleCreature enemy, bool immediate = false)
    {
        enemyCreatureName.text = enemy.Name;
        if (immediate)
        {
            enemyCreatureBar.fillAmount = (float)enemy.Health / (float)enemy.MaxHealth;
        }
        else
        {
            if (enemyBarMoving)
            {
                StopAllCoroutines();
                enemyBarMoving = false;
            }
            StartCoroutine(AnimateHealthBar(enemyCreatureBar, enemyCreatureBar.fillAmount, (float)enemy.Health / (float)enemy.MaxHealth, false));
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
        while (playerCreatureBar.fillAmount != to)
        {
            playerCreatureBar.fillAmount = Mathf.Lerp(from, to, fillTime / BarSlideTimeInSecs);
            fillTime += Time.deltaTime;
            if (fillTime > BarSlideTimeInSecs)
            {
                fillTime = BarSlideTimeInSecs;
            }
            yield return null;
        }
        playerCreatureBar.fillAmount = to;
        if (barIsPlayers)
        {
            playerBarMoving = false;
        }
        else
        {
            enemyBarMoving = false;
        }
    }
}
