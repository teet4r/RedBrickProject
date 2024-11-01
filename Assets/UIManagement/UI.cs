using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RectTransform RectTr => rectTr;
    protected RectTransform rectTr;

    protected virtual void Awake()
    {
        rectTr = GetComponent<RectTransform>();
    }

    public virtual void OnPressEsc()
    {
        UIManager.Instance.Hide(this);
    }
}