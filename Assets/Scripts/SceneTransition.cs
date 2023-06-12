using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TMP_Text _loadingPercentage;
    [SerializeField] private Image _loadingProgressBar;

    private const float _DesirableLoadigTime = 3.0f;
    private const int _DesirableLoadigIterations = 100;

    private float _iterationTime = _DesirableLoadigTime / _DesirableLoadigIterations;
    private bool _isLoading = false;
    public void LoadScene(string sceneName)
    {
        if (_isLoading == false)
        {
            StartCoroutine(loadSceneAsync(sceneName));
            _isLoading = true;
        }
    }

    private IEnumerator loadSceneAsync(string sceneName)
    {
        AsyncOperation loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        loadingSceneOperation.allowSceneActivation = false;
        _loadingScreen.SetActive(true);

        for (int i = 0; i < _DesirableLoadigIterations; i++)
        {
            float progressImitation = _iterationTime * i/_DesirableLoadigTime;
            _loadingProgressBar.fillAmount = progressImitation;
            string percent = (progressImitation * 100).ToString("F0");
            _loadingPercentage.text = "Loading... " + percent + "%";
            yield return new WaitForSeconds(_iterationTime);
        }
        loadingSceneOperation.allowSceneActivation = true;
        _isLoading = false;
    }
}