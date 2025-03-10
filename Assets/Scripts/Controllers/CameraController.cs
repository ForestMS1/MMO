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
        RaycastHit hit;
        if (Physics.Raycast(player.transform.position, _dir, out hit, _dir.magnitude,LayerMask.GetMask("Wall")))
        {
            float dist = (hit.point - player.transform.position).magnitude * 0.8f;
            transform.position = player.transform.position + _dir.normalized * dist;
        }
        else
        {
            transform.position = player.transform.position + _dir;
            transform.LookAt(player.transform.position);
        }
    }

    public void SetQuaterView(Vector3 dir)
    {
        _mode = Define.CameraMode.QuaterView;
        _dir = dir;
    }

}
