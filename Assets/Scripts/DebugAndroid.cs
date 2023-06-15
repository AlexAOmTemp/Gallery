using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugAndroid : MonoBehaviour
{
    [SerializeField] SceneTransition _transition;
    public bool BackButton;
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Autorotate" + ScreenRotator.IsAutoRotationEnable.ToString());
        GUI.Label(new Rect(10, 20, 100, 20), SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (BackButton == true)
        {
            _transition.BackPressed();
            BackButton = false;
        }
    }
}
