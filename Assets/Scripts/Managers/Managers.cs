using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장 (전역 변수)

    static Managers Instance { get { Init(); return s_instance; } } //유일한 매니저를 갖고온다 (프로퍼티)
    
    private InputManager _input = new InputManager();
    private ResourceManager _resource = new ResourceManager();
    private UIManager _ui = new UIManager();
    public static InputManager Input { get { return Instance._input; } }
    public static ResourceManager Resource { get {return Instance._resource; } }
    public static UIManager UI { get { return Instance._ui; } }
    void Start()
    {
        Init();
    }
    
    void Update()
    {
        _input.OnUpdate();
    }
    
    //싱글톤 패턴으로 매니저는 한개만 존재
    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject("@Managers");
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go); //중요한 오브젝트가 지워지지 않도록 설정
            s_instance = go.GetComponent<Managers>();
        }
    }
}
