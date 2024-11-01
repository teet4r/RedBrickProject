using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject go_Option;

    private bool _isOption = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnPlay()
    {
        if (_isOption) return;

        Debug.Log("Play");
    }

    public void BtnOpenOption()
    {
        Debug.Log("Option");
        go_Option.SetActive(true);
        _isOption = !_isOption;
    }

    public void BtnExit()
    {
        if (_isOption) return;

        Debug.Log("Exit");
        Application.Quit();
    }

    public void BtnCloseOption()
    {
        go_Option.SetActive(false);
        _isOption = !_isOption;
    }


}
