using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectText : MonoBehaviour
{
    [SerializeField] private Text _connectText;

    public void UpdateConnect(float connectCount)
    {
        _connectText.text = connectCount.ToString();
    }
}
