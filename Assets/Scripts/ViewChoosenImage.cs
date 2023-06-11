using UnityEngine;
using UnityEngine.UI;

public class ViewChoosenImage : MonoBehaviour
{
    void Awake()
    {
        var choosenImage = GameObject.Find("ChoosenImage");
        if (choosenImage == null)
            Debug.LogError("Saved image not found");
        var loadedSprite = choosenImage.GetComponent<Image>().sprite;
        this.GetComponent<Image>().sprite = loadedSprite;
    }
}
