using UnityEngine;
using UnityEngine.UI;

public class ImageViewButton : MonoBehaviour
{
    private SceneTransition _transition;
    private GameObject _choosenImage;
    private bool _IsLoaded = false;

    public void SpriteLoaded()
    {
        _IsLoaded = true;
    }

    private void Start()
    {
        _transition = GameObject.Find("SceneTransition").GetComponent<SceneTransition>();
        if (_transition == null)
            Debug.LogError("Scene Transition object not found");
        _choosenImage = GameObject.Find("ChoosenImage");
        if (_choosenImage == null)
            Debug.LogError("Choosen image object not found");
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(onButtonClick);
    }
    private void onButtonClick()
    {
        if (_IsLoaded == true)
        {
            var sprite = this.GetComponent<Image>().sprite;
            _choosenImage.GetComponent<Image>().sprite = sprite;
            _transition.LoadScene("ViewScene");
        }
    }

}
