using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    public void UpdateTime(float time)
    {
        if (time < 5f)
        {
            _timerText.color = Color.red;
        }
        _timerText.text = time.ToString("F2");
    }
}
