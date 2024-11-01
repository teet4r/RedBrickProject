using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class Ingame
{
    public static ReactiveProperty<float> Timer = new(); // 남은 시간
    public static ReactiveProperty<int> MatchedCouples = new(); // 매치된 커플 수

    public static void Initialize()
    {
        Timer.Value = 60f;
        MatchedCouples.Value = 0;
    }
}
