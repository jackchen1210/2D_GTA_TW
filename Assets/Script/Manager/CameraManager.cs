using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviourSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void ResetCameraToFollowPlayer()
    {
        var playerTrans = PlayerController.GetInstance().transform;
        virtualCamera.Follow = playerTrans;
        virtualCamera.ForceCameraPosition(playerTrans.position,Quaternion.identity);
    }
}
