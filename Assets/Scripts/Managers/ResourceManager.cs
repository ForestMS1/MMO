using UnityEngine;

public class ResourceManager
{
    private T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");

        if (prefab == null)
        {
            Debug.LogError($"Failed to load {path}");
            return null;
        }
        
        return GameObject.Instantiate(prefab, parent);
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            return;
        }
        
        Object.Destroy(go);
    }
}
