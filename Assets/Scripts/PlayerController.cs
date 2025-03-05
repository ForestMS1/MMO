using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [SerializeField] float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //GameObject(Player)
        //Transform
        //PlayerController(*)
    void Update()
    {
        //월드좌표계, 로컬좌표계 구분해야함!!
        //World -> Local
        //transform.TransformDirection() //캐릭터가 바라보는 방향이 바뀌어도 원하는대로 동작한다.
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * speed);
        }
    }
}
