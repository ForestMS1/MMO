using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private int _order = 0;
    
    Stack<UI_Popup> _stack = new Stack<UI_Popup>();
    UI_Scene _sceneUI = null;

    public GameObject Root 
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject("@UI_Root");
            }

            return root; //중복 코드 -> 프로퍼티
        }
    }
    
    //외부에서 팝업같은UI가 켜질때 역으로 SetCanvas를 요청해서 자기 Canavas에 있는 오더를 채워달라고 부탁
    //나는 이제 켜질건데 기존UI와 우선순위를 정해주세요
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.getOrAddComponenet<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true; //캔버스 안에 캔버스가 있을 때 부모가 어떤 값을 가지던 나는 무조건 내 sorting order를 가질거야

        if (sort)
        {
            canvas.sortingOrder = _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }
        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");

        T sceneUI = Util.getOrAddComponenet<T>(go);
        _sceneUI = sceneUI;
        
        go.transform.SetParent(Root.transform);
        
        return sceneUI;
    }
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
        
        go.transform.SetParent(Root.transform);
        
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
