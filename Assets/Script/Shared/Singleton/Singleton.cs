using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    #region Fields

    private static T _instance;

    #endregion

    #region Properties

    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    _instance = new GameObject("(Instance) " + typeof(T)).AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    #endregion

    #region Build-in Methods

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
