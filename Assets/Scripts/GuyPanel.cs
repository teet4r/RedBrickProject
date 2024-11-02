using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuyPanel : MonoBehaviour
{
    [SerializeField] private Image _face;
    [SerializeField] private Image _top;
    [SerializeField] private Image _hair;

    public void SetRandomClothes()
    {
        _face.gameObject.SetActive(false);

        var topIdx = Random.Range(0, 2);
        _top.sprite = SpriteLoader.Instance.Load($"BoyTop{topIdx}");

        var hairIdx = Random.Range(0, 2);
        _hair.sprite = SpriteLoader.Instance.Load($"BoyHair{hairIdx}");
    }

    public void SetHappyFace() => _SetFace(1);
    public void SetBadFace() => _SetFace(0);

    private void _SetFace(int idx)
    {
        _face.gameObject.SetActive(true);
        _face.sprite = SpriteLoader.Instance.Load($"BoyFace{idx}");
    }
}
