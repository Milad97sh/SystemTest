using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPopup : PopUp
{
    public string username;
    public Button enter;
    public override void Starting(System.Action<object> callback)
    {
        //base.Start();
        enter.onClick.AddListener(() => callback(enter));
    }

    public void WriteSth()
    {
        Debug.Log("it worked!");
    }
}
