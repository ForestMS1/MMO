using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    public abstract void Init();
    
    protected enum Buttons
    {
        PointButton
    }
    protected enum Texts
    {
        PointText,
        ScoreText
    }

    protected enum GameObjects
    {
        TestObject,
    }

    protected enum Images
    {
        ItemIcon,
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];
        _objects.Add(typeof(T), objs);

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
            {
                //enum으로 정의한 타입과 같은 이름의 게임오브젝트가 있는지 찾는다.(UI_Button오브젝트 산하에서)
                objs[i] = Util.FindChild(gameObject, names[i], true);
            }
            else
            {
                objs[i] = Util.FindChild<T>(gameObject, names[i], true);
            }
            Debug.Log($"Binding {names[i]}: {(objs[i] != null ? "Success" : "Failed")}");
        }
    }

    protected T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
        {
            return null;
        }
        else
        {
            return objects[idx] as T;
        }
    }

    protected TextMeshProUGUI GetText(int idx)
    {
        return Get<TextMeshProUGUI>(idx);
    }

    protected Button GetButton(int idx)
    {
        return Get<Button>(idx);
    }

    protected Image GetImage(int idx)
    {
        return Get<Image>(idx);
    }

    public static void AddUIEvnet(GameObject go, Action<PointerEventData> action, Define.UIEvnet type = Define.UIEvnet.Click)
    {
        UI_EventHandler evt = Util.getOrAddComponenet<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvnet.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvnet.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;
                break;
            
        }
        
        evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });
    }
}
