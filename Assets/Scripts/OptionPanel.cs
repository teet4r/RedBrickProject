using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private Slider _bgmSlider;
    [SerializeField] private Slider _sfxSlider;

    private void Awake()
    {
        _bgmSlider.value = AudioManager.Instance.Bgm.Volume;
        _sfxSlider.value = AudioManager.Instance.Sfx.Volume;

        _bgmSlider.onValueChanged.AddListener(volume => AudioManager.Instance.Bgm.Volume = volume);
        _sfxSlider.onValueChanged.AddListener(volume => AudioManager.Instance.Sfx.Volume = volume);
    }
}
