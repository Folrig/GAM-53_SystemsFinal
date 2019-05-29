using UnityEngine;
using UnityEngine.UI;

public class BattleMoveListItem : MonoBehaviour
{
    public delegate void StringToVoidDelegate(string arg);
    public event StringToVoidDelegate DeleteClicked;
    
    public void DeleteButtonClicked()
    {

    }
}
