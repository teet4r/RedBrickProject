using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject scenes;
    public GameObject fadeBackGround;

    private Image[] _sceneImages = null;

    private int _sceneNum = 0;
    private Color _orgColor = new Color(1, 1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        _sceneImages = scenes.GetComponentsInChildren<Image>();
        _sceneNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _sceneImages.Length >= _sceneNum)
        {
            PassScene();
        }
    }

    void PassScene()
    {
        if (_sceneNum < _sceneImages.Length)
        {
            _OnScene();
            _sceneNum++;
        }
        else if (_sceneNum == _sceneImages.Length)
        {
            StartCoroutine(CoFadeOut());
            _sceneNum++;
        }
    }

    private void _OnScene()
    {
        _sceneImages[_sceneNum].color = _orgColor;
    }

    IEnumerator CoFadeOut()
    {
        float curTime = 0.00f;
        float fadeTime = 0.5f;

        Debug.Log("Start Fade Out");

        var canvasGroup = fadeBackGround.GetComponent<CanvasGroup>();
        while (curTime <= fadeTime)
        {
            canvasGroup.alpha = (Mathf.Lerp(0f, 1f, curTime / fadeTime));

            Debug.Log("Fade Out");

            curTime += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = 1.0f;

        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("IngameScene");

        yield break;
    }

}
