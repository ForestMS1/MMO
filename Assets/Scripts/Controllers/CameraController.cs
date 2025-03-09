using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Define.CameraMode _mode = Define.CameraMode.QuaterView;
    
    [SerializeField]
    Vector3 _dir;
    
    [SerializeField]
    GameObject player;


    void LateUpdate()
    {
        transform.position = player.transform.position + _dir;
        transform.LookAt(player.transform.position);
    }

    public void SetQuaterView(Vector3 dir)
    {
        _mode = Define.CameraMode.QuaterView;
        _dir = dir;
    }

}
