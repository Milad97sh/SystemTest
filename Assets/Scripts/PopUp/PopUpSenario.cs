using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

[CreateAssetMenu(fileName = "New PopupManager", menuName = "PopUpManager")]
public class PopUpSenario : ScriptableSingleton<PopUpSenario>
{

    public PopUps[] popUp = new PopUps[10];
    [HideInInspector] public bool applyPrefab;

    public void Start()
    {

    }

    //public void ShowPopup(PopupType type, System.Action callBack)
    //{
        
    //    var pop = Instantiate(popUp[(int)type].popUp);
    //    pop.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
    //}


}

//[System.Serializable]
//public class PopUps
//{
//    public GameObject popUp;
//    public bool selected;
//    public PopupType popUpType;
//}


