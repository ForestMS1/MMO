using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order = 0;
    
    Stack<UI_Popup> _stack = new Stack<UI_Popup>();

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");

        T popup = Util.getOrAddComponenet<T>(go);
        _stack.Push(popup);
        _order = _stack.Count;
        
        return popup;
    }
    
    //ClosePopupUI의 안전빵
    public void ClosePopupUI(UI_Popup popup)
    {
        if (_stack.Count == 0)
        {
            return;
        }

        if (!_stack.Peek().Equals(popup))
        {
            Debug.Log($"Close Popup Failed!");
            return;
        }
        
        ClosePopupUI();
    }
    
    //제일 최신 팝업을 닫음
    public void ClosePopupUI()
    {
        if (_stack.Count == 0)
        {
            return;
        }

        UI_Popup popup = _stack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        popup = null;

        _order--;
    }

    public void CloseAllPopupUI()
    {
        if (_stack.Count == 0)
        {
            return;
        }

        while (_stack.Count > 0)
        {
            ClosePopupUI();
        }
    }
    
}
