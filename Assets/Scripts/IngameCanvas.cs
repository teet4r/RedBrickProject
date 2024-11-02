using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameCanvas : MonoBehaviour
{
    public static IngameCanvas Instance => _instance;
    private static IngameCanvas _instance;

    public TimerText TimerText => _timerText;
    public ConnectText ConnectText => _connectText;
    public GuyPanel GuyPanel => _guyPanel;
    public DreamGirlPanel DreamGirlPanel => _dreamGirlPanel;

    [SerializeField] private TimerText _timerText;
    [SerializeField] private ConnectText _connectText;
    [SerializeField] private GuyPanel _guyPanel;
    [SerializeField] private DreamGirlPanel _dreamGirlPanel;

    private void Awake()
    {
        _instance = this;
    }
}
