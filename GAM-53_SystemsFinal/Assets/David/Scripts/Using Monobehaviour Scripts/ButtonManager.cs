using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private PokeMawnDexMainScript pokeMainScript;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject firstCreateScreen;
    [SerializeField] private GameObject secondCreateScreen;

    [SerializeField] private InputField creatorNameInput;
    [SerializeField] private Dropdown creatorAttributeDropDown;
    [SerializeField] private Slider creatorBalanceSlider;
    [SerializeField] private Text creatorPowerReadout;
    [SerializeField] private Text creatorAgilityReadout;

    [SerializeField] private int abilityScoreBase = 25;
    [SerializeField] private int abilitySliderScope = 50;

    private string creatorName;
    private Attribute creatorAttribute;
    private int creatorPowerScore;
    private int creatorAgilityScore;

    public void CreateClicked()
    {
        SwapMenus(mainMenu, firstCreateScreen);
        InitCreateScreen();
    }

    public void CreateCancelClicked()
    {
        SwapMenus(firstCreateScreen, mainMenu);
    }

    public void CreateNextClicked()
    {

    }

    private void SwapMenus(GameObject oldMenu, GameObject newMenu)
    {
        oldMenu.SetActive(false);
        newMenu.SetActive(true);
    }

    private void InitCreateScreen()
    {
        // Initialize first screen
        creatorName = string.Empty;
        creatorAttribute = Attribute.Fire;
        creatorNameInput.text = string.Empty;
        creatorAttributeDropDown.value = 0;
        int halfSlider = abilitySliderScope / 2;
        creatorPowerScore = abilityScoreBase + halfSlider;
        creatorAgilityScore = abilityScoreBase + abilitySliderScope - halfSlider;
        creatorBalanceSlider.value = halfSlider;
        creatorPowerReadout.text = creatorPowerScore.ToString();
        creatorAgilityReadout.text = creatorAgilityScore.ToString();
    }

    public void NameFieldChanged()
    {
        creatorName = creatorNameInput.text;
    }

    public void AttributeDropDownChanged()
    {
        creatorAttribute = (Attribute)creatorAttributeDropDown.value;
    }

    public void BalanceSliderChanged()
    {
        creatorPowerScore = abilityScoreBase + abilitySliderScope - (int)creatorBalanceSlider.value;
        creatorAgilityScore = abilityScoreBase + (int)creatorBalanceSlider.value;
        creatorPowerReadout.text = creatorPowerScore.ToString();
        creatorAgilityReadout.text = creatorAgilityScore.ToString();
    }
}
