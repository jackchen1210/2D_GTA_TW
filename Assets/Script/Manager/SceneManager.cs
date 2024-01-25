public class SceneManager : MonoBehaviourSingleton<SceneManager>
{
    public int CurrentSceneIndex { get; private set; } = -1;

    protected override void OnAwake()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += SceneManager_sceneLoaded;
    }

    public void LoadScene(int sceneIndex)
    {
        CurrentSceneIndex = sceneIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }

    private void SceneManager_sceneLoaded(UnityEngine.SceneManagement.Scene arg0, UnityEngine.SceneManagement.LoadSceneMode arg1)
    {
        CameraManager.GetInstance().ResetCameraToFollowPlayer();
    }
}
