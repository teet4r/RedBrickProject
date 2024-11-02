using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _breakHash = Animator.StringToHash("Break");
    private int _connectHash = Animator.StringToHash("Connect");

    public void PlayBreakingHeart() => _animator.SetTrigger(_breakHash);
    public void PlayConnectingHeart() => _animator.SetTrigger(_connectHash);
    public void Refresh() => _animator.Rebind();
}
