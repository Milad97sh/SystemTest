using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class PopUpManager : MonoBehaviour
{
    public static PopUpManager instance;
    public List<PopUps> popUpPrefabs = new List<PopUps>(10);
    public Canvas canvas;


    void Awake()
    {
        instance = this;
    }

    public void ShowPopup(PopupType type, System.Action<object> callBack, Vector2 position, bool exitPermision = true, bool backgroundBlur = true)
    {

        var pop = Instantiate(popUpPrefabs[(int)type].popUp, position, Quaternion.identity, canvas.transform);
        ScalePopup(pop.transform.GetChild(0));
        pop.Starting(callBack);
        var backgroundImage = pop.transform.GetComponent<Image>().color;
        if (!backgroundBlur)
        {
            backgroundImage.a = 0;
            pop.transform.GetComponent<Image>().color = backgroundImage;
        }
        if (exitPermision)
            pop.transform.GetComponent<Button>().onClick.AddListener(() => ScalePopup(pop.transform.GetChild(0)));
    }

    public void ShowPopup(PopupType type, System.Action<object> callBack, bool exitPermision = true, bool backgroundBlur = true)
    {
        var pop = Instantiate(popUpPrefabs[(int)type].popUp, canvas.transform);
        ScalePopup(pop.transform.GetChild(0));
        pop.Starting(callBack);
        var backgroundImage = pop.transform.GetComponent<Image>().color;
        if (!backgroundBlur)
        {
            backgroundImage.a = 0;
            pop.transform.GetComponent<Image>().color= backgroundImage;
        }
        if (exitPermision)
            pop.transform.GetComponent<Button>().onClick.AddListener(() => ScalePopup(pop.transform.GetChild(0)));
    }


    public void ScalePopup(Transform pop)
    {
        if (pop.transform.localScale == Vector3.zero)
            pop.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        else
            pop.transform.DOScale(0, 0.5f).SetEase(Ease.InBack).OnComplete(() => pop.parent.gameObject.SetActive(false));
    }
}
[System.Serializable]
public class PopUps
{
    public PopUp popUp;
    public PopupType popUpType;
}

public enum PopupType
{
    smallWindow,
    dialogPopup,
    loginWindow,
    smallPopup
}
