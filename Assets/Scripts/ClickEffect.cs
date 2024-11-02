using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : PoolObject
{
    [SerializeField] private Animator _animator;

    private int _clickHash = Animator.StringToHash("Click");

    public void Play()
    {
        _Play().Forget();
    }

    private async UniTask _Play()
    {
        _animator.SetTrigger(_clickHash);
        await UniTask.Delay(500, cancellationToken: disableCancellationToken);
        ObjectPoolManager.Instance.Return(this);
    }
}
