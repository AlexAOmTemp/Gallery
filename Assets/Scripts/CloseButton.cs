using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CloseButton : MonoBehaviour
{
    // Start is called before the first frame update
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
