using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Bgm : MonoBehaviour
{
    public bool IsLoaded => _audioSource != null;
    public bool IsPlaying => _audioSource.isPlaying;

    private AudioSource _audioSource;
    private Dictionary<BgmName, AudioClip> _bgms = new();

    public float Volume
    {
        get => _audioSource.volume;
        set
        {
            _audioSource.volume = value;
            PlayerPrefs.SetFloat("BgmVolume", value);
            PlayerPrefs.Save();
        }
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Initialize()
    {
        _bgms.Clear();
        _audioSource.volume = PlayerPrefs.GetFloat("BgmVolume", 1f);
    }

    public void Play(BgmName bgm)
    {
        if (!_bgms.TryGetValue(bgm, out AudioClip clip))
        {
            clip = Resources.Load<AudioClip>($"Bgms/{bgm}");
            _bgms.Add(bgm, clip);
            //var handle = Addressables.LoadAssetAsync<AudioClip>(bgm.ToString());
            //handle.WaitForCompletion();
            //_bgms.Add(bgm, clip = handle.Result);
            //Addressables.Release(handle);
        }

        if (clip == _audioSource.clip)
            return;

        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void Stop()
    {
        if (!_audioSource.isPlaying)
            return;

        _audioSource.Stop();
    }
}
