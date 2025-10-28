using UnityEditorInternal;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance()
    {
        if (_instance == null)
        {
            _instance = (T)GameObject.FindAnyObjectByType(typeof(T));

            if (_instance == null )
            {
                GameObject tempInstance = new GameObject();
                T newInstnace = tempInstance.AddComponent<T>();
                newInstnace.name = $"@{typeof(T).Name}";

                _instance = newInstnace;
            }
        }

        return _instance;
    }
}
