using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    #region Adjustable Fields
    [SerializeField] private int abilityScoreBase = 25;
    [SerializeField] private int abilitySliderScope = 50;
    #endregion Adjustable Fields

    #region Inspector Plugins
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject firstCreateScreen;
    [SerializeField] private GameObject secondCreateScreen;

    [SerializeField] private Image creatorBodyDisplay;
    [SerializeField] private InputField creatorNameInput;
    [SerializeField] private Dropdown creatorAttributeDropDown;
    [SerializeField] private Dropdown creatorBodyDropDown;
    [SerializeField] private Slider creatorBalanceSlider;
    [SerializeField] private Text creatorPowerReadout;
    [SerializeField] private Text creatorAgilityReadout;
    [SerializeField] private InputField creatorMoveNameInput;
    [SerializeField] private Dropdown creatorMoveAttribDropDown;
    [SerializeField] private Slider creatorMoveFocusSlider;
    [SerializeField] private Transform creatorMoveListPanel;
    [SerializeField] private Button creatorFinishButton;

    [SerializeField] private GameObject moveListItemPrefab;
    #endregion Inspector Plugins

    #region Members
    private PokeMawnDexMainScript pokeMainScript;
    private Sprite creatorAvatar;
    private string creatorName;
    private Attribute creatorAttribute;
    private int creatorPowerScore;
    private int creatorAgilityScore;
    private List<BattleMove> creatorMoves = new List<BattleMove>();
    #endregion Members

    #region Event Handlers
    public void CreateClicked()
    {
        SwapMenus(mainMenu, firstCreateScreen);
        InitTempBattleCreature();
        InitFirstCreateScreen();
    }

    public void CreateCancelClicked()
    {
        SwapMenus(firstCreateScreen, mainMenu);
    }

    public void CreateNextClicked()
    {
        SwapMenus(firstCreateScreen, secondCreateScreen);
        InitSecondCreateScreen();
    }

    public void FinishClicked()
    {
        BattleCreature newCreature = new BattleCreature(creatorName, creatorAttribute, 100, 100, creatorPowerScore, creatorAgilityScore);
        newCreature.Avatar = creatorAvatar;
        foreach (BattleMove move in creatorMoves)
        {
            newCreature.moves.Add(move);
        }
        //pokeMainScript.creatures.Add(newCreature);
        SwapMenus(secondCreateScreen, mainMenu);
    }

    public void NameFieldChanged()
    {
        creatorName = creatorNameInput.text;
    }

    public void AttributeDropDownChanged()
    {
        creatorAttribute = (Attribute)creatorAttributeDropDown.value;
    }

    public void BodyDropDownChanged()
    {
        creatorBodyDisplay.sprite = creatorBodyDropDown.options[creatorBodyDropDown.value].image;
        creatorAvatar = creatorBodyDisplay.sprite;
    }

    public void BalanceSliderChanged()
    {
        creatorPowerScore = abilityScoreBase + abilitySliderScope - (int)creatorBalanceSlider.value;
        creatorAgilityScore = abilityScoreBase + (int)creatorBalanceSlider.value;
        creatorPowerReadout.text = creatorPowerScore.ToString();
        creatorAgilityReadout.text = creatorAgilityScore.ToString();
    }

    public void MoveAdded()
    {
        if (creatorMoves.Count >= 4)
        {
            return;
        }

        // Verify move validity
        string newMoveName = creatorMoveNameInput.text.Trim();
        if (newMoveName == "")
        {
            return;
        }
        foreach (BattleMove move in creatorMoves)
        {
            if (move.name == newMoveName)
            {
                return;
            }
        }

        BattleMove newMove = new BattleMove
        {
            name = newMoveName,
            attribute = (Attribute)creatorMoveAttribDropDown.value,
            usesPower = Mathf.Approximately(creatorMoveFocusSlider.value, 0.0f)
        };

        creatorMoves.Add(newMove);
        AddMoveListItem(newMove);

        CheckMoveQuantity();

        ResetMoveFields();
    }

    public void MoveDeleted(string moveName)
    {
        foreach (BattleMove move in creatorMoves)
        {
            if (move.name == moveName)
            {
                creatorMoves.Remove(move);
                break;
            }
        }
        CheckMoveQuantity();
    }
    #endregion Event Handlers

    #region Helper Functions
    private void AddMoveListItem(BattleMove move)
    {
        GameObject item = Instantiate(moveListItemPrefab, creatorMoveListPanel);
        BattleMoveListItem itemScript = item.GetComponent<BattleMoveListItem>();
        itemScript.PopulateFields(move.name, move.attribute.ToString(), move.usesPower ? "Power" : "Agility");
        itemScript.DeleteClicked += MoveDeleted;
    }

    private void CheckMoveQuantity()
    {
        if (creatorMoves.Count > 0 && creatorMoves.Count <= 4)
        {
            creatorFinishButton.enabled = true;
        }
        else
        {
            creatorFinishButton.enabled = false;
        }
    }

    private void InitTempBattleCreature()
    {
        creatorAvatar = creatorBodyDropDown.options[0].image;
        creatorName = string.Empty;
        creatorAttribute = Attribute.Fire;
        int halfSlider = abilitySliderScope / 2;
        creatorPowerScore = abilityScoreBase + halfSlider;
        creatorAgilityScore = abilityScoreBase + abilitySliderScope - halfSlider;
    }

    private void InitFirstCreateScreen()
    {
        creatorNameInput.text = string.Empty;
        creatorAttributeDropDown.value = 0;
        creatorBalanceSlider.value = abilitySliderScope / 2;
        creatorPowerReadout.text = creatorPowerScore.ToString();
        creatorAgilityReadout.text = creatorAgilityScore.ToString();
    }

    private void InitSecondCreateScreen()
    {
        ResetMoveFields();

        foreach (Transform moveListItem in creatorMoveListPanel)
        {
            Destroy(moveListItem.gameObject);
        }

        foreach (BattleMove tempMove in creatorMoves)
        {
            AddMoveListItem(tempMove);
        }

        CheckMoveQuantity();
    }

    private void ResetMoveFields()
    {
        creatorMoveNameInput.text = string.Empty;
        creatorMoveAttribDropDown.value = 0;
        creatorMoveFocusSlider.value = 0.0f;
    }

    private void SwapMenus(GameObject oldMenu, GameObject newMenu)
    {
        oldMenu.SetActive(false);
        newMenu.SetActive(true);
    }
    #endregion Helper Functions
}
