using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Ingame : MonoBehaviour
{
    public static Ingame Instance => _instance;
    private static Ingame _instance;

    public readonly ReactiveProperty<float> Timer = new(); // 남은 시간
    public readonly ReactiveProperty<int> MatchedCouples = new(); // 매치된 커플 수
    public readonly ReactiveProperty<GirlBody> CurrentGirl = new();
    private readonly List<GirlBody> Girls = new();

    private int _girlIndex = 0;

    private void Awake()
    {
        _instance = this;

        Initialize();
    }

    private void Start()
    {
        Observable.EveryUpdate()
            .Subscribe(_ =>
            {
                Timer.Value -= Time.deltaTime;
                if (Timer.Value < 0f)
                    Timer.Value = 0f;
            })
            .AddTo(gameObject);

        Vector2 pos = Vector2.zero;
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                for (int k = 0; k < 3; ++k)
                {
                    var girl = ObjectPoolManager.Instance.Get<GirlBody>();
                    pos.x = Random.Range(-8.5f, 8.5f);
                    pos.y = Random.Range(-4.5f, 1.5f);
                    girl.Tr.position = pos;
                    girl.SetClothes(i, j, k);
                    Girls.Add(girl);
                }
        for (int i = 0; i < 4; ++i)
        {
            var idx = Random.Range(0, Girls.Count);
            Girls.RemoveAt(idx);
            ObjectPoolManager.Instance.Return(Girls[idx]);
        }

        CurrentGirl.Value = Girls[_girlIndex++];

        AudioManager.Instance.Bgm.Play(BgmName.Bgm0);
    }

    public void Initialize()
    {
        Timer.Value = 60f;
        MatchedCouples.Value = 0;
        Girls.Clear();
        CurrentGirl.Value = null;
        _girlIndex = 0;
    }
}
