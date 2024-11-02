using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Girl : PoolObject
{
    public Sprite HairSprite => _hairRenderer.sprite;
    public Sprite TopSprite => _topRenderer.sprite;
    public Sprite BottomSprite => _bottomRenderer.sprite;

    [SerializeField] private SpriteRenderer _bodyRenderer;
    [SerializeField] private SpriteRenderer _hairRenderer;
    [SerializeField] private SpriteRenderer _topRenderer;
    [SerializeField] private SpriteRenderer _bottomRenderer;
    [SerializeField] private Animator _animator;

    private int _walkHash = Animator.StringToHash("Walk");

    private CancellationTokenSource _moveToken;
    private TweenerCore<Vector3, Vector3, DG.Tweening.Plugins.Options.VectorOptions> _moveTween;

    public void SetOrderInLayer(int layer)
    {
        _bodyRenderer.sortingOrder = layer;
        _hairRenderer.sortingOrder = layer + 1;
        _topRenderer.sortingOrder = layer + 2;
        _bottomRenderer.sortingOrder = layer + 3;
    }

    public void SetClothes(int hairIdx, int topIdx, int bottomIdx)
    {
        _hairRenderer.sprite = SpriteLoader.Instance.Load($"GirlHair{hairIdx}");
        _topRenderer.sprite = SpriteLoader.Instance.Load($"GirlTop{topIdx}");
        _bottomRenderer.sprite = SpriteLoader.Instance.Load($"GirlBottom{bottomIdx}");
    }

    public bool IsEqual(Girl other)
    {
        return _hairRenderer.sprite == other._hairRenderer.sprite
            && _topRenderer.sprite == other._topRenderer.sprite
            && _bottomRenderer.sprite == other._bottomRenderer.sprite;
    }

    private void OnMouseUp()
    {
        _OnMouseUp().Forget();
    }

    private async UniTask _OnMouseUp()
    {
        if (!Ingame.Instance.IsClickable)
            return;

        Ingame.Instance.IsClickable = false;
        if (IsEqual(Ingame.Instance.CurrentGirl))
        {
            IngameCanvas.Instance.DreamGirlPanel.HeartAnimator.PlayConnectingHeart();
            IngameCanvas.Instance.GuyPanel.SetHappyFace();
            Ingame.Instance.DestroyGirl(this);
            ++Ingame.Instance.MatchedCouples.Value;
        }
        else
        {
            IngameCanvas.Instance.DreamGirlPanel.HeartAnimator.PlayBreakingHeart();
            IngameCanvas.Instance.GuyPanel.SetBadFace();
            Ingame.Instance.Timer.Value -= 1f;
        }

        await UniTask.Delay(500);
        Ingame.Instance.SetNextPair();
        Ingame.Instance.IsClickable = true;
    }

    public void StartMove()
    {
        StopMove();
        _moveToken = new();
        _Move().Forget();
    }

    public void StopMove()
    {
        if (_moveToken != null && !_moveToken.IsCancellationRequested)
        {
            _moveToken.Cancel();
            _moveToken.Dispose();
        }
        _moveToken = null;
        if (_moveTween != null)
        {
            DOTween.Kill(_moveTween);
            _moveTween = null;
        }
    }

    private async UniTask _Move()
    {
        Vector2 targetPos = new();

        while (_moveToken != null && !_moveToken.IsCancellationRequested)
        {
            if (Random.Range(0, 2) == 0)
            {
                _animator.Rebind();
                await UniTask.Delay(Random.Range(500, 2000), cancellationToken: _moveToken.Token);
            }
            else
            {
                _animator.SetTrigger(_walkHash);
                var curPosX = transform.position.x;
                targetPos.x = Random.Range(-8.5f, 8.5f);
                targetPos.y = Random.Range(-4.5f, 1.5f);
                var flipX = targetPos.x < curPosX;
                _bodyRenderer.flipX = flipX;
                _hairRenderer.flipX = flipX;
                _topRenderer.flipX = flipX;
                _bottomRenderer.flipX = flipX;
                var speed = Random.Range(3f, 8f);
                _moveTween = transform.DOMove(targetPos, speed);
                await _moveTween.AsyncWaitForCompletion();
            }
        }
    }
}
