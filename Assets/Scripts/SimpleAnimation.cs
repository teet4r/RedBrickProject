using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class SimpleAnimation : PoolObject
{
    public bool isLoop;
    public bool isPause;
    public bool autoStart;
    public event Action OnEnd;

    [SerializeField][Min(1)] private int framesPerSprite = 6;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _image;
    private Coroutine _coroutine;

    protected override void OnEnable()
    {
        base.OnEnable();

        if (autoStart)
            Play();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        Stop();
    }

    public void Play()
    {
        if (_coroutine == null)
            _coroutine = StartCoroutine(_Routine());
        else
            isPause = false;
    }

    public void Pause()
    {
        if (_coroutine != null)
            isPause = true;
    }

    public void Stop()
    {
        if (_coroutine == null)
            return;

        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator _Routine()
    {
        int i, frame = 0, length = _sprites.Length;

        do
        {
            i = 0;

            while (i < length)
            {
                if (isPause)
                {
                    yield return null;
                    continue;
                }

                if (++frame >= framesPerSprite)
                {
                    frame = 0;
                    _image.sprite = _sprites[i++];
                }

                yield return null;
            }
        } while (isLoop);

        OnEnd?.Invoke();
    }
}
