using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectText : MonoBehaviour
{
    [SerializeField] private Text _connectText;

    public void UpdateConnect(int connectCount, int maxCount)
    {
        _connectText.text = $"{connectCount}/{maxCount}";
    }
}
