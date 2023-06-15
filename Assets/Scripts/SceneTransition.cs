using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Linq;
public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TMP_Text _loadingPercentage;
    [SerializeField] private Image _loadingProgressBar;

    private const float _DesirableLoadigTime = 3.0f;
    private const int _DesirableLoadigIterations = 100;

    private float _iterationTime = _DesirableLoadigTime / _DesirableLoadigIterations;
    private bool _isLoading = false;
    private bool _inProcess = false;

    public void BackPressed()
    {
        if (_inProcess == false && _isLoading == false) //protection against accidental double click and block while loading
        {
            _inProcess = true;
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "ViewScene")
            {
                SceneManager.UnloadSceneAsync("ViewScene");
                ScreenRotator.ChangeRotation(false);
                StartCoroutine(backClickDelay());
            }
            else if (sceneName == "GalleryScene")
            {
                LoadScene("MenuScene");
            }
            else // MenuScene
            {
                Application.Quit();
            }
        }
    }
    public void LoadScene(string sceneName)
    {
        if (_isLoading == false)
        {
            bool isViewScene = false;
            if (sceneName == "ViewScene")
                isViewScene = true;
            StartCoroutine(loadSceneAsync(sceneName, isViewScene));
            _isLoading = true;
        }
    }

    private IEnumerator loadSceneAsync(string sceneName, bool isViewScene)
    {
        AsyncOperation loadingSceneOperation;
        if (isViewScene == true)
            loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        else
            loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;
        
        _loadingScreen.SetActive(true);

        for (int i = 0; i < _DesirableLoadigIterations; i++) //loading imitation
        {
            float progressImitation = _iterationTime * i / _DesirableLoadigTime;
            _loadingProgressBar.fillAmount = progressImitation;
            string percent = (progressImitation * 100).ToString("F0");
            _loadingPercentage.text = "Загрузка... " + percent + "%";
            yield return new WaitForSeconds(_iterationTime);
        }

        loadingSceneOperation.allowSceneActivation = true; 
        while (loadingSceneOperation.isDone == false) //wait for real scene loading
            yield return new WaitForSeconds(_iterationTime);

        if (isViewScene == true)
        {
            ScreenRotator.ChangeRotation(true);
            setLoadedSceneActive(sceneName);
        }
        _loadingScreen.SetActive(false);
        _isLoading = false;
        _inProcess = false;
    }
    private IEnumerator backClickDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _inProcess = false;
    }
    private void setLoadedSceneActive(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                SceneManager.SetActiveScene(scene);
                break;
            }
        }
    }
}
