using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviourSingleton<SceneManager>
{
    public event Action<bool> OnBlackScreenEnableChanged;
    public int CurrentSceneIndex { get; private set; } = -1;

    [SerializeField] private Image blackScreenImg;
    private bool isShowBlackScreen;
    private float fadedTime = 1f;

    public void LoadScene(int sceneIndex)
    {
        CurrentSceneIndex = sceneIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    public void ShowLoadingScreen()
    {
        isShowBlackScreen = true;
        blackScreenImg.color = Color.clear;
        blackScreenImg.gameObject.SetActive(true);
        blackScreenImg.DOFade(1, fadedTime).SetEase(Ease.OutQuad);
        OnBlackScreenEnableChanged?.Invoke(true);
    }
    public void HideLoadingScreen()
    {
        if (!isShowBlackScreen)
        {
            return;
        }
        CameraManager.GetInstance().ResetCameraToFollowPlayer();
        isShowBlackScreen = false;
        blackScreenImg.color = Color.black;
        blackScreenImg.DOFade(0, fadedTime).SetEase(Ease.OutQuad).OnComplete(() =>
        {
            blackScreenImg.gameObject.SetActive(false);
            OnBlackScreenEnableChanged?.Invoke(false);
        });
    }
}
