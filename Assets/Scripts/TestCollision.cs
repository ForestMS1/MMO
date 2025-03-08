using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up, transform.forward * 10f, Color.red);
    
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, transform.forward * 10f,out hit, 10f))
        {
            Debug.Log($"Raycast Hit! {hit.collider.gameObject.name}");
        }
    }
}
