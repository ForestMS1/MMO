using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach (Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        
        //실제 인벤토리 정보를 참고해서 만들것
        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.UI.MakeSubItem<UI_Inven_Item>(parent : gridPanel.transform).gameObject;
            item.transform.name = $"UI_Inven_Item {i}";
            
            UI_Inven_Item invenItem = item.getOrAddComponenet<UI_Inven_Item>();
            invenItem.SetInfo($"Apple{i}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
