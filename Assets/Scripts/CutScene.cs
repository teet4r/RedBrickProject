using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public GameObject _scenes;
    public Image[] _sceneImages = null;

    private int _sceneNum = 0;
    private Color _orgColor = new Color(1, 1, 1, 1); 

    // Start is called before the first frame update
    void Start()
    {
        _sceneImages = _scenes.GetComponentsInChildren<Image>();
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
    }

    private void _OnScene()
    {
        _sceneImages[_sceneNum].color = _orgColor;
    }


}
