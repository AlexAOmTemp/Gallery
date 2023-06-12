using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGalleryButton : MonoBehaviour
{
    [SerializeField] SceneTransition _transition;

    private void Start()
    {
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(onButtonClick);
    }
    private void onButtonClick()
    {
        _transition.LoadScene("GalleryScene");
    }
}
