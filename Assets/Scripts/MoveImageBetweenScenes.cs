using UnityEngine;

public class MoveImageBetweenScenes : MonoBehaviour
{
    private static MoveImageBetweenScenes _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
