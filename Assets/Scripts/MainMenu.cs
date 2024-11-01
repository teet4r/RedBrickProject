using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
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
        Debug.Log("Play");
    }

    public void BtnOption()
    {
        Debug.Log("Option");
    }

    public void BtnExit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }



}
