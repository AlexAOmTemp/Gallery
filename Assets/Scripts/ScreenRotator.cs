using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenRotator : MonoBehaviour
{
    public static bool IsAutoRotationEnable { get; private set; } = false;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public static void ChangeRotation(bool autorotate)
    { 
        if (autorotate == true)
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            IsAutoRotationEnable = true;
        }
        else
        {
            Screen.orientation = ScreenOrientation.Portrait;
            IsAutoRotationEnable = false;
        }

    }
}
