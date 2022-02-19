using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour
{
    public Button[] allButtons;
    public virtual void Starting(System.Action<object> callback)
    {
        if (allButtons[0])
        {
            foreach (var button in allButtons)
            {
                if (button.name == "Next")
                {
                    button.onClick.AddListener(() => tooltip(callback, button.transform.position));
                }
                else
                    button.onClick.AddListener(() => callback(button));
            }
        }
    }

    void tooltip(System.Action<object> callback, Vector2 pos)
    {
        PopUpManager.instance.ShowPopup(PopupType.smallPopup, GameManager.instance.callBack, pos, true, false);
    }
}

