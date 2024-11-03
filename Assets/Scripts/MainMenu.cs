using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject go_Option;
    [SerializeField] GameObject go_CutScene;

    private bool _isOption = false;

    private void Start()
    {
        AudioManager.Instance.Bgm.Volume = PlayerPrefs.GetFloat("BgmVolume", 1f);
        AudioManager.Instance.Sfx.Volume = PlayerPrefs.GetFloat("SfxVolume", 1f);
        AudioManager.Instance.Bgm.Play(BgmName.Bgm0);
    }

    public void BtnPlay()
    {
        if (_isOption) return;

        go_CutScene.SetActive(true);
    }

    public void BtnOpenOption()
    {
        go_Option.SetActive(true);
        _isOption = !_isOption;
    }

    public void BtnCloseOption()
    {
        go_Option.SetActive(false);
        _isOption = !_isOption;
    }

    public void PlayClickSfx()
    {
        AudioManager.Instance.Sfx.Play(SfxName.Click0);
    }
}
