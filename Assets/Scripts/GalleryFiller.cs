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
    private const int _ItemAmount = 66;
    private const string _Url = "http://data.ikppbb.com/test-task-unity-data/pics/";
    private List<GameObject> _contentItems = new List<GameObject>();

    private void Awake()
    {
        _scroll.onValueChanged.AddListener((Vector2 val) => scrollbarCallback(val));
        _imageLoader.ImageIsLoaded += onImageLoaded;

        float width = Display.main.systemWidth;
        float height = Display.main.systemHeight;
        float proportion = height / width;
        int baseItemsCount = 8;
        if (proportion > 1.9)
            baseItemsCount = 10;
        for (int i = 0; i< baseItemsCount; i++)
            addNewItem();
    }
    private void scrollbarCallback(Vector2 value)
    {
        if (_scroll.verticalNormalizedPosition <= 0.005f)
            for (int i = 0; i < 2; i++)
                addNewItem();
    }
    private void onImageLoaded(Sprite sprite)
    {
        int index = int.Parse(sprite.name);
        _contentItems[index].GetComponent<Image>().sprite = sprite;
        _contentItems[index].GetComponent<ImageViewButton>().SpriteLoaded();
    }
    private string getCurrentImageName(int number)
    {
        return _Url + number.ToString() + ".jpg";
    }
    private void addNewItem()
    {
        if (_contentItems.Count < _ItemAmount)
        {
            var item = Instantiate(_contentItemPrefab, _contentContainer.transform);
            _imageLoader.LoadImage(getCurrentImageName(_contentItems.Count+1), _contentItems.Count.ToString());
            _contentItems.Add(item);
        }
    }
}
