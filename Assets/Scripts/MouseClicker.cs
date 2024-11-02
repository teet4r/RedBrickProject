using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetMouseButtonDown(0))
            {
                var effect = ObjectPoolManager.Instance.Get<ClickEffect>();
                effect.Tr.position = Input.mousePosition;
                effect.Play();
            }
        }).AddTo(gameObject);
    }
}
