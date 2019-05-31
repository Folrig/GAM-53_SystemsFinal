using UnityEngine;
using UnityEngine.UI;

public class BattleMoveListItem : MonoBehaviour
{
    [SerializeField] private Text nameField;
    [SerializeField] private Text typeField;
    [SerializeField] private Text focusField;

    public delegate void StringToVoidDelegate(string arg);
    public event StringToVoidDelegate DeleteClicked;
    
    public void DeleteButtonClicked()
    {
        if (DeleteClicked != null)
        {
            DeleteClicked(nameField.text);
        }
        Destroy(gameObject);
    }

    public void PopulateFields(string nameOfMove, string moveType, string moveFocus)
    {
        nameField.text = nameOfMove;
        typeField.text = moveType;
        focusField.text = moveFocus;
    }

	private void OnDestroy()
	{
        DeleteClicked = null;
	}
}
