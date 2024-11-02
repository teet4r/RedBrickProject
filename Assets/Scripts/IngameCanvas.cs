using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCanvas : MonoBehaviour
{
    public static IngameCanvas Instance => _instance;
    private static IngameCanvas _instance;

    [SerializeField] private TimerText _timerText;
    [SerializeField] private ConnectText _connectText;

    private void Awake()
    {
        _instance = this;
    }


}
