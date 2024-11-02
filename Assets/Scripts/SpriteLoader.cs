using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SpriteLoader : SingletonBehaviour<SpriteLoader>
{
    private Dictionary<string, Sprite> _dict = new();

    public Sprite Load(string sourceName)
    {
        if (!_dict.TryGetValue(sourceName, out Sprite sprite))
        {
            _dict.Add(sourceName, sprite = Resources.Load<Sprite>($"Sprites/{sourceName}"));
            //var asset = Addressables.LoadAssetAsync<Sprite>(sourceName);
            //asset.WaitForCompletion();
            //if (asset.Result != null)
            //{
            //    _dict.Add(sourceName, sprite = asset.Result);
            //    Addressables.Release(asset);
            //}
            //else
            //    return null;
        }
        return sprite;
    }

    public void Clear()
    {
        _dict.Clear();
    }
}
