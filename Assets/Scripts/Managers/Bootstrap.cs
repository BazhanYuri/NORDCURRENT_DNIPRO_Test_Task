using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CameraManager _cameraManager;
        [SerializeField] private SpawnManager _spawnManager;


        private void Start()
        {
            SetDependencies();
        }
        


        private void SetDependencies()
        {
            _spawnManager.Init(SaveConteiner.Instance.GameConfig, SaveConteiner.Instance.EnemyConfig,
               SaveConteiner.Instance.PlayerConfig);
        }

    }
}

