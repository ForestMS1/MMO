using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard; //다른곳에서 구독했을수도있음. 중복방지
        //인풋매니저 KeyAction에 OnKeyboard 구독신청
        //인풋매니저한테. 어떤키가 눌리면. OnKeyboard 함수를 실행해라.
        Managers.Input.KeyAction += OnKeyboard;
    }
    
    //GameObject(Player)
        //Transform
        //PlayerController(*)
    void OnKeyboard()
    {
        //월드좌표계, 로컬좌표계 구분해야함!!
        //World -> Local
        //transform.TransformDirection() //캐릭터가 바라보는 방향이 바뀌어도 원하는대로 동작한다.
        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.05f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.05f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.05f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.05f);
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
