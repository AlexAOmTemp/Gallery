using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGalleryButton : MonoBehaviour
{
    void Start()
    {
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(onButtonClick);
    }

    private void onButtonClick()
    {
        SceneManager.LoadScene("GalleryScene");
    }
}
