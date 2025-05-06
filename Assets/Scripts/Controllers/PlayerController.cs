using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] 
    float speed = 10.0f;


    //private bool _moveToDest = false; // 마우스로 찍은곳 이동?
    private Vector3 _destPos;
    private Animator animator;

    public enum PlayerState
    {
        Die,
        Moving,
        Idle,
    }
    PlayerState _state = PlayerState.Idle;
    void Awake()
    {
       animator = GetComponent<Animator>();
       //Managers.Resource.Instantiate("UI/UI_Button");
    }
    void Start()
    {
        // Managers.Input.KeyAction -= OnKeyboard; //다른곳에서 구독했을수도있음. 중복방지
        // //인풋매니저한테. 어떤키가 눌리면. OnKeyboard 함수를 실행해라.
        // Managers.Input.KeyAction += OnKeyboard; //인풋매니저 KeyAction에 OnKeyboard 구독신청
        
        
        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
        
        //TEMP
        Managers.UI.ShowSceneUI<UI_Inven>();
    }

    void UpdateDie()
    {
        //아무것도 못함
    }

    void UpdateMoving()
    {
        //이동처리
        Vector3 dir = _destPos - transform.position;
        //목적지에 도착
        if (dir.magnitude < 0.0001f)
        {
            _state = PlayerState.Idle;
        }
        else
        {
            float moveDist = Mathf.Clamp(speed * Time.deltaTime, 0, dir.magnitude);
            transform.position += dir.normalized * moveDist;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), speed * Time.deltaTime);
        }
        
        //애니메이션처리
        animator.SetFloat("speed", speed);
    }

    void UpdateIdle()
    {
        //애니메이션 처리
        animator.SetFloat("speed", 0f);
    }
    void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;
            case PlayerState.Moving:
                UpdateMoving();
                break;
            case PlayerState.Die:
                UpdateDie();
                break;
        }
    }
    

    // void OnKeyboard()
    // {
    //     //월드좌표계, 로컬좌표계 구분해야함!!
    //     //World -> Local
    //     //transform.TransformDirection() //캐릭터가 바라보는 방향이 바뀌어도 원하는대로 동작한다.
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.forward);
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.05f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
    //     }
    //     if (Input.GetKey(KeyCode.A))
    //     {
    //         // transform.rotation = Quaternion.LookRotation(Vector3.left);
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.05f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
    //     }
    //     if (Input.GetKey(KeyCode.S))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.back);
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.05f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
    //     }
    //
    //     if (Input.GetKey(KeyCode.D))
    //     {
    //         //transform.rotation = Quaternion.LookRotation(Vector3.right);
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.05f);
    //         transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
    //     }
    //     
    //     _moveToDest = false;
    // }

    void OnMouseClicked(Define.MouseEvent mouseEvent)
    {
        if (_state == PlayerState.Die)
        {
            return;
        }
        
        if (mouseEvent != Define.MouseEvent.Click)
        {
            return;
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 500.0f, Color.red, 1.0f);
        LayerMask mask = LayerMask.GetMask("Wall");
        
        if (Physics.Raycast(ray, out RaycastHit hit, 500.0f, mask))
        {
            _destPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            _state = PlayerState.Moving;
        }
    }
}
