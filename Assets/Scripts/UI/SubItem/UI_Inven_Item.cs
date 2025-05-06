using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inven_Item : UI_Base
{

    enum GameObjects
    {
        ItemIcon,
        ItemNameText
    }

    private string _name;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));

        Get<GameObject>((int)GameObjects.ItemNameText).GetComponent<TextMeshProUGUI>().text = _name;

        GameObject go = Get<GameObject>((int)GameObjects.ItemIcon);
        BindEvent(go, (PointerEventData data) => { Debug.Log($"Item Click! {_name}");});
    }

    public void SetInfo(string name)
    {
        _name = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
