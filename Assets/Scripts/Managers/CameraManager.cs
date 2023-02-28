using UnityEngine;
using Cinemachine;

namespace TanksBattle
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _playerCameraFollow;



        private void OnEnable()
        {
            SpawnManager.PlayerSpawned += SetPlayerForCamera;
        }
        private void OnDisable()
        {
            SpawnManager.PlayerSpawned -= SetPlayerForCamera;
        }






        private void SetPlayerForCamera(Transform player)
        {
            _playerCameraFollow.Follow = player;
        }
    }
}

