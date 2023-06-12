using UnityEngine;

public class SingletonPrefab<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Fields

    private static T _instance;

    #endregion

    #region Properties

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

    #endregion

    #region Methods

    private static T GetFromResources()
    {
        T instance = Resources.Load<T>(typeof(T).FullName);
        GameObject parent = GameObject.Find("(Instances)");
        if(parent != null)
        {
            return Instantiate(instance, parent.transform);
        }
        
        parent = new GameObject("(Instances)");
        return Instantiate(instance, parent.transform);
    }

    #endregion

    #region Build-in Methods

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
