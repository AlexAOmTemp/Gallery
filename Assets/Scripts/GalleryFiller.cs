using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GalleryFiller : MonoBehaviour
{
    [SerializeField] private ImageLoader _imageLoader;
    [SerializeField] private GameObject _contentContainer;
    [SerializeField] private GameObject _contentItemPrefab;
    [SerializeField] private ScrollRect _scroll;

    private GridLayoutGroup _layout;
    private const int itemAmount = 66;
    private const string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private List<GameObject> contentItems = new List<GameObject>();
    void Awake()
    {
        _scroll.onValueChanged.AddListener((Vector2 val) => ScrollbarCallback(val));
        _imageLoader.ImageIsLoaded += onImageLoaded;
        for (int i = 0; i< 8; i++)
            addNewItem();
       

    }
    void ScrollbarCallback(Vector2 value)
    {
        
        if (_scroll.verticalNormalizedPosition <= 0.005f)
            for (int i = 0; i < 2; i++)
                addNewItem();
    }

    private void onImageLoaded(Sprite sprite)
    {
        int index = int.Parse(sprite.name);
        contentItems[index].GetComponent<Image>().sprite = sprite;
        contentItems[index].GetComponent<ImageViewButton>().SpriteLoaded();
    }

    private string getCurrentImageName(int number)
    {
        return _url + number.ToString() + ".jpg";
    }
    private void addNewItem()
    {
        if (contentItems.Count < itemAmount)
        {
            var item = Instantiate(_contentItemPrefab, _contentContainer.transform);
            _imageLoader.LoadImage(getCurrentImageName(contentItems.Count+1), contentItems.Count.ToString());
            contentItems.Add(item);
        }
    }
}
