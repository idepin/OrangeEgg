using UnityEngine;

public class SingletonPrefab<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    _instance = GetFromResources();
                }
            }
            return _instance;
        }
    }

    private static T GetFromResources()
    {
        T instance = Resources.Load<T>(typeof(T).FullName);
        GameObject parent = GameObject.Find("(Instances)");
        if(parent != null)
        {
            return Instantiate(instance, parent.transform);
        }
        else
        {
            parent = new GameObject("(Instances)");
            return Instantiate(instance, parent.transform);
        }
        
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
    }
}
