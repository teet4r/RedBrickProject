using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlBody : PoolObject
{
    [SerializeField] private SpriteRenderer _hairRenderer;
    [SerializeField] private SpriteRenderer _topRenderer;
    [SerializeField] private SpriteRenderer _bottomRenderer;

    public void SetRandomClothes()
    {
        _hairRenderer.sprite = SpriteLoader.Instance.Load($"GirlHair{Random.Range(0, 3)}");
        _topRenderer.sprite = SpriteLoader.Instance.Load($"GirlTop{Random.Range(0, 3)}");
        _bottomRenderer.sprite = SpriteLoader.Instance.Load($"GirlBottom{Random.Range(0, 3)}");
    }
}
