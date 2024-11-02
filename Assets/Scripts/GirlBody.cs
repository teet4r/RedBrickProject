using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GirlBody : PoolObject
{
    [SerializeField] private SpriteRenderer _hairRenderer;
    [SerializeField] private SpriteRenderer _topRenderer;
    [SerializeField] private SpriteRenderer _bottomRenderer;

    public void SetRandomClothes()
    {
        SetClothes(Random.Range(0, 3), Random.Range(0, 3), Random.Range(0, 3));
    }

    public void SetClothes(int hairIdx, int topIdx, int bottomIdx)
    {
        _hairRenderer.sprite = SpriteLoader.Instance.Load($"GirlHair{hairIdx}");
        _topRenderer.sprite = SpriteLoader.Instance.Load($"GirlTop{topIdx}");
        _bottomRenderer.sprite = SpriteLoader.Instance.Load($"GirlBottom{bottomIdx}");
    }

    private void OnMouseUp()
    {

    }
}
