using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public System.Action<object> callBack;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        callBack = PrintSomthing;
        //PopUpManager.instance.ShowPopup(PopupType.dialogPopup, callBack);
        //PopUpManager.instance.ShowPopup(PopupType.loginWindow, callBack);
        AudioManager.instance.Setting(true , true, true);
        AudioManager.instance.PlayMusic();
        AudioManager.instance.Play("magic");

    }


    public void muteAudio()
    {
        if (AudioManager.instance.muted)
        {
            AudioManager.instance.Setting(true, true, true);
            AudioManager.instance.muted = false;
        }
        else
        {
            AudioManager.instance.Setting(false, false, false);
            AudioManager.instance.muted = true;
        }
    }

    public void Playsub(string name)
    {
        AudioManager.instance.PlaySubMusic(name);
    }
    public void Stopsub()
    {
        AudioManager.instance.StopSubMusic();
    }

    void PrintSomthing(object sentence)
    {
        Debug.Log(sentence);

    }
}
