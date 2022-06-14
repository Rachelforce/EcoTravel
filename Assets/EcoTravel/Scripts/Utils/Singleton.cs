using UnityEngine;

/// <summary>
/// http://wiki.unity3d.com/index.php/Singleton
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Check to see if we're about to be destroyed.
    //private static bool m_ShuttingDown = false;
    private static object lockInstance = new object();
    private static T instance;

    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            //if (m_ShuttingDown)
            //{
            //    //Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
            //    //    "' already destroyed. Returning null.");
            //    return null;
            //}

            lock (lockInstance)
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).Name;

                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }


    //private void OnApplicationQuit()
    //{
    //    m_ShuttingDown = true;
    //}


    //private void OnDestroy()
    //{
    //    m_ShuttingDown = true;
    //}
}
