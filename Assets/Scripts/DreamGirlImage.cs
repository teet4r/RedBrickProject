using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamGirlImage : MonoBehaviour
{
    [SerializeField] private Image _bottomImage;
    [SerializeField] private Image _topImage;
    [SerializeField] private Image _hairImage;

    public void SetBottom(Sprite sprite) => _bottomImage.sprite = sprite;
    public void SetTop(Sprite sprite) => _topImage.sprite = sprite;
    public void SetHair(Sprite sprite) => _hairImage.sprite = sprite;
}
