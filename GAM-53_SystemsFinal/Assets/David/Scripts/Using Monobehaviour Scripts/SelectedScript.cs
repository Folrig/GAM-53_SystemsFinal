using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectedScript : MonoBehaviour 
{
    public bool isSelected = false;

    public void OnSelect(BaseEventData eventData)
	{
        isSelected = true;
        if (isSelected == true)
        {
            Debug.Log(this.gameObject.name + "is selected");
        }
        else
        {
            Debug.Log(this.gameObject.name + "is NOT selected");
        }
	}
}
