using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers s_instance; //유일성 보장 (전역 변수)

    public static Managers Instance { get { Init(); return s_instance; } } //유일한 매니저를 갖고온다 (프로퍼티)

    void Start()
    {
        Init();
    }
    
    void Update()
    {
        
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
