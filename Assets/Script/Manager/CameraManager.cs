using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviourSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void ResetCameraToFollowPlayer()
    {
        virtualCamera.Follow = PlayerController.GetInstance().transform;
    }
}
