using UnityEngine;
using UnityEngine.SceneManagement;

public class HardwareBackButton : MonoBehaviour
{
    [SerializeField] SceneTransition _transition;
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                var scene = SceneManager.GetActiveScene();
                if (scene.name == "ViewScene")
                {
                    _transition.LoadScene("GalleryScene");
                }
                else if (scene.name == "GalleryScene")
                {
                    _transition.LoadScene("MenuScene");
                }
                else // MenuScene
                {
                    Application.Quit();
                }
            }
        }
    }
}
