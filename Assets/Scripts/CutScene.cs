using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (Input.GetKeyDown(KeyCode.Space) && _sceneNum <= 3)
        {
            _OnScene();
            _sceneNum++;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && _sceneNum == 3)
        {
            StartCoroutine(CoFadeOut());
        }
    }

    void PassScene()
    {

    }

    private void _OnScene()
    {
        _sceneImages[_sceneNum].color = _orgColor;
    }

    IEnumerator CoFadeOut()
    {
        float curTime = 0.00f;
        float fadeTime = 0.5f;

        while (curTime >= fadeTime)
        {
            fadeBackGround.GetComponent<CanvasRenderer>().SetAlpha(Mathf.Lerp(0f, 1f, curTime / fadeTime));

            curTime += Time.deltaTime;
            yield return null;
        }

        yield break;
    }

}
