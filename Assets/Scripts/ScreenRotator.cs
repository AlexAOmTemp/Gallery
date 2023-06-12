using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenRotator : MonoBehaviour
{
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        var scene = SceneManager.GetActiveScene();
        if (scene.name == "ViewScene")
            Screen.orientation = ScreenOrientation.AutoRotation;
    }
}
