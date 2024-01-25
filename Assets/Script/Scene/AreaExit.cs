using System.Collections;
using UnityEngine;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private int loadSceneIndex;

    private WaitForSecondsRealtime waitForSeconds = new WaitForSecondsRealtime(1);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Tool.IsPlayer(collision))
        {
            SceneManager.GetInstance().ShowLoadingScreen();
            StartCoroutine(DelayLoad());
        }
    }

    private IEnumerator DelayLoad()
    {
        yield return waitForSeconds;
        SceneManager.GetInstance().LoadScene(loadSceneIndex);
    }
}
