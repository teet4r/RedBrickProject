using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : SimpleAnimation
{
    protected override void Awake()
    {
        base.Awake();

        OnEnd += () => ObjectPoolManager.Instance.Return(this);
    }
}
