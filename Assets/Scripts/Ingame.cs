using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

public class Ingame : MonoBehaviour
{
    public static Ingame Instance => _instance;
    private static Ingame _instance;

    public bool IsClickable;
    public readonly ReactiveProperty<float> Timer = new(); // 남은 시간
    public readonly ReactiveProperty<int> MatchedCouples = new(); // 매치된 커플 수
    private readonly List<Girl> _girls = new();

    public Girl CurrentGirl => _currentGirl;
    private Girl _currentGirl;

    private bool _isShownResult;

    private void Awake()
    {
        _instance = this;

        Initialize();
    }

    public void StartGame()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                Timer.Value -= Time.deltaTime;

                if (Timer.Value < 0f)
                    Timer.Value = 0f;

                if (Timer.Value <= 0f || MatchedCouples.Value >= 20)
                {
                    if (_isShownResult)
                        return;

                    _isShownResult = true;
                    IngameCanvas.Instance.ResultPanel.gameObject.SetActive(true);
                    IngameCanvas.Instance.ResultPanel.ShowResult(MatchedCouples.Value >= 20);
                    ObjectPoolManager.Instance.HideAll();
                }

                IngameCanvas.Instance.TimerText.UpdateTime(Timer.Value);
            })
            .AddTo(gameObject);

        MatchedCouples
            .Subscribe(matchedCount => IngameCanvas.Instance.ConnectText.UpdateConnect(matchedCount, 20))
            .AddTo(gameObject);

        Vector2 pos = Vector2.zero;
        int layer = 0;
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                for (int k = 0; k < 3; ++k)
                {
                    var girl = ObjectPoolManager.Instance.Get<Girl>();
                    pos.x = Random.Range(-8.5f, 8.5f);
                    pos.y = Random.Range(-4.5f, 1.5f);
                    girl.Tr.position = pos;
                    girl.SetClothes(i, j, k);
                    _girls.Add(girl);
                    girl.SetOrderInLayer(layer += 4);
                    girl.StartMove();
                }
        for (int i = 0; i < 30; ++i)
        {
            int idx1 = Random.Range(0, _girls.Count);
            int idx2 = Random.Range(0, _girls.Count);
            var g1 = _girls[idx1];
            _girls[idx1] = _girls[idx2];
            _girls[idx2] = g1;
        }
        for (int i = 0; i < 4; ++i)
            DestroyGirl(_girls[_girls.Count - 1]);

        SetNextPair();
    }

    public void Initialize()
    {
        IsClickable = true;
        Timer.Value = 80;
        MatchedCouples.Value = 0;
        _currentGirl = null;
        _isShownResult = false;
        _girls.Clear();
    }

    public void SetNextPair()
    {
        if (_girls.Count == 0)
            return;

        _currentGirl = _girls[Random.Range(0, _girls.Count)];

        var girlImage = IngameCanvas.Instance.DreamGirlPanel.DreamGirlImage;
        girlImage.SetHair(_currentGirl.HairSprite);
        girlImage.SetTop(_currentGirl.TopSprite);
        girlImage.SetBottom(_currentGirl.BottomSprite);
        IngameCanvas.Instance.GuyPanel.SetRandomClothes();
        IngameCanvas.Instance.DreamGirlPanel.HeartAnimator.Refresh();
    }

    public void DestroyGirl(Girl girl)
    {
        if (_girls.Remove(girl))
        {
            girl.StopMove();
            ObjectPoolManager.Instance.Return(girl);
        }
    }
}
