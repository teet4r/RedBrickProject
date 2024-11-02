using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    public void UpdateTime(float time)
    {
        _timerText.text = time.ToString("F2");
    }
}
