using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Mouse0))
    //     {
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     
    //         Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 1.0f);
    //
    //         LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
    //         //int mask = (1 << 8);
    //         
    //         if (Physics.Raycast(ray, out RaycastHit hit, 100.0f, mask))
    //         {
    //             //hit.collider.gameObject.layer.
    //             Debug.Log($"ray hit {hit.collider.gameObject.name}");
    //         }
    //     }
    // }
}
