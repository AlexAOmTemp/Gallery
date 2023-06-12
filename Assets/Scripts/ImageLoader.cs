using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    public delegate void ImageLoaded(Sprite image);
    public event ImageLoaded ImageIsLoaded;

    public void LoadImage(string url, string newName)
    {
        StartCoroutine(getTexture(url, newName));
    }

    private IEnumerator getTexture(string url, string newName)
    {
        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
            webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(webRequest.error);
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
            sprite.name = newName;
            ImageIsLoaded?.Invoke(sprite);
        }
    }
}
