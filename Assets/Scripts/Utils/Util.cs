using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //parent, childName -> 찾고자 하는 자식이름, recursive -> 재귀적으로 계속 찾을것인지 여부
    public static T FindChild<T>(GameObject parent, string childName = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (parent == null)
        {
            return null;
        }

        if (!recursive)
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
