using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class Ingame
{
    public static ReactiveProperty<int> Life = new();
    public static ReactiveProperty<float> Timer = new(); // 남은 시간
    public static ReactiveProperty<int> MatchedCouples = new();

    public static void Initialize()
    {
        Life.Value = 3;
        Timer.Value = 60f;
        MatchedCouples.Value = 0;
    }
}
