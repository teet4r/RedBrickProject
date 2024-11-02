using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private GameObject _successImage;
    [SerializeField] private GameObject _failImage;
    [SerializeField] private Text _remainTimeText;
    [SerializeField] private Text _failContentText;
    [SerializeField] private Button _goHome;

    private void Awake()
    {
        _goHome.onClick.AddListener(() => SceneManager.Instance.LoadSceneAsync(SceneName.MainScene).Forget());
    }

    public void ShowResult(bool success)
    {
        _successImage.SetActive(success);
        _failImage.SetActive(!success);
        _remainTimeText.text = $"{(80 - Ingame.Instance.Timer.Value).ToString("F2")}초 만에";
        _failContentText.text = $"{20 - Ingame.Instance.MatchedCouples.Value}커플이 모자라서 잘렸다...";
    }
}
