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

    private void Awake()
    {
        _instance = this;

        Initialize();
    }

    private void Start()
    {
        //var girl = ObjectPoolManager.Instance.Get<GirlBody>();
        //girl.Tr.position = Vector2.zero;

        //girl.SetRandomClothes();
    }

    public void Initialize()
    {
        Timer.Value = 60f;
        MatchedCouples.Value = 0;
    }
}
