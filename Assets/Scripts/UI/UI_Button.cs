using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    enum Buttons
    {
        PointButton
    }
    enum Texts
    {
        PointText,
        ScoreText
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            //enum으로 정의한 타입과 같은 이름의 게임오브젝트가 있는지 찾는다.(UI_Button오브젝트 산하에서)
            objs[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }
    
    //C# Reflection
    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<TextMeshPro>(typeof(Texts));
    }
    public void OnClickedButton()
    {
        Debug.Log("Clicked button");
    }
}
