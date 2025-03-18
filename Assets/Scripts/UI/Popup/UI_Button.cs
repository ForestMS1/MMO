using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    private int _score = 0;
    //C# Reflection
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));
        

            
        GameObject bt = GetButton((int)Buttons.PointButton).gameObject;
        AddUIEvnet(bt, OnClickedButton, Define.UIEvnet.Click);

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvnet(go, (PointerEventData data) => { go.transform.position = data.position; },
            Define.UIEvnet.Drag);
    }

    public void OnClickedButton(PointerEventData eventData)
    {
        _score++;
        Debug.Log("Clicked button");
        GetText((int)Texts.ScoreText).text = $"current score: {_score}";
    }
}
