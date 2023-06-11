using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ImageViewButton : MonoBehaviour
{
    private GameObject _choosenImage;
    private bool _IsLoaded = false;
    public void SpriteLoaded()
    {
        _IsLoaded = true;
    }
    private void Start()
    {
        _choosenImage = GameObject.Find("ChoosenImage");
        if (_choosenImage == null)
            Debug.LogError("Choosen image not found");
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(onButtonClick);
    }

    private void onButtonClick()
    {
        if (_IsLoaded == true)
        {
            var sprite = this.GetComponent<Image>().sprite;
            _choosenImage.GetComponent<Image>().sprite = sprite;
            SceneManager.LoadScene("ViewScene");
        }
    }

}
