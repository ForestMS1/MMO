using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
    public static T getOrAddComponenet<T>(this GameObject go) where T : UnityEngine.Component
    {
        return Util.getOrAddComponenet<T>(go);
    }
    
    public static void AddUIEvnet(this GameObject go, Action<PointerEventData> action, Define.UIEvnet type = Define.UIEvnet.Click)
    {
        UI_Base.BindEvent(go, action, type);    
    }
}
