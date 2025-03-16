using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    //C# Reflection
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        
        Get<TextMeshProUGUI>((int)Texts.ScoreText).text = "Test Bind";
    }
    public void OnClickedButton()
    {
        Debug.Log("Clicked button");
    }
}
