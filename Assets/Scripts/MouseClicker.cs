using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClicker : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTr;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && RectTransformUtility.ScreenPointToWorldPointInRectangle(_canvasRectTr, Input.mousePosition, null, out Vector3 Point))
        {
            var effect = ObjectPoolManager.Instance.Get<ClickEffect>();
            effect.Tr.SetParent(_canvasRectTr);
            effect.Tr.position = Point;
            effect.Play();
        }
    }
}
