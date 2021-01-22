using UnityEngine;

public class Loader<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
                                                //Наход с блока T
            if (instance == null) instance = FindObjectOfType<T>(); // Если лвл не создан -> создать
            else if (instance != FindObjectOfType<T>()) Destroy(FindObjectOfType<T>()); //Если лвл не должен создаваться он удаляется
            DontDestroyOnLoad(FindObjectOfType<T>());

            return Instance;
        }
    }
}
