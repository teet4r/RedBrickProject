using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamGirlPanel : MonoBehaviour
{
    public HeartAnimator HeartAnimator => _heartAnimator;
    public DreamGirlImage DreamGirlImage => _dreamGirlImage;

    [SerializeField] private HeartAnimator _heartAnimator;
    [SerializeField] private DreamGirlImage _dreamGirlImage;
}
