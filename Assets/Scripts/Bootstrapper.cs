using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private void Start()
    {
        _Boot().Forget();
    }

    private async UniTask _Boot()
    {
        await UniTask.WaitUntil(() =>
            SceneManager.Instance.IsLoaded ||
            AudioManager.Instance.IsLoaded ||
            ObjectPoolManager.Instance.IsLoaded ||
            SpriteLoader.Instance.IsLoaded
        );

        SceneManager.Instance.LoadSceneAsync(SceneName.MainScene).Forget();
    }
}
