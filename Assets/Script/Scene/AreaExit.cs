using UnityEngine;

public class AreaExit : MonoBehaviour
{
    [SerializeField] private int loadSceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Tool.IsPlayer(collision))
        {
            SceneManager.GetInstance().LoadScene(loadSceneIndex);
        }
    }
}
