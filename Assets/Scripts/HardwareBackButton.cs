using UnityEngine;

public class HardwareBackButton : MonoBehaviour
{
    [SerializeField] SceneTransition _transition;
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                _transition.BackPressed();
            }
        }
    }
}
