using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static T getOrAddComponenet<T>(GameObject go) where T : UnityEngine.Component
    {
        T component = go.GetComponent<T>();
        if (component == null)
        {
            component = go.AddComponent<T>();
        }
        return component;
    }
    public static GameObject FindChild(GameObject parent, string childName = null, bool recursive = false)
    {
        Transform transform = FindChild<Transform>(parent, childName, recursive);
        if (transform == null)
        {
            return null;
        }
        return transform.gameObject;
    }

    //parent, childName -> 찾고자 하는 자식이름, recursive -> 재귀적으로 계속 찾을것인지 여부
    public static T FindChild<T>(GameObject parent, string childName = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (parent == null)
        {
            return null;
        }

        if (recursive == false)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                if (string.IsNullOrEmpty(childName) || child.name == childName)
                {
                    T component = child.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                }
            }
        }
        else //재귀적으로 찾기
        {
            foreach (T component in parent.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(childName) || component.name == childName)
                {
                    return component;
                }
            }
        }

        return null;
    }
}
