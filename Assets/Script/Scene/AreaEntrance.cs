using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    private void Start()
    {
        if(gameObject.scene.buildIndex == SceneManager.GetInstance().CurrentSceneIndex)
        {
            PlayerController.GetInstance().SetPosition(transform.position);
        }
    }
}
