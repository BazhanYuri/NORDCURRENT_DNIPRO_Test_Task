using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    public class SaveConteiner : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private GameConfig _gameConfig;


        public static SaveConteiner Instance;
        public PlayerConfig PlayerConfig { get => _playerConfig;}
        public GameConfig GameConfig { get => _gameConfig;}
        public EnemyConfig EnemyConfig { get => _enemyConfig;}



        private void Awake()
        {
            Instance = this;

            _playerConfig = _playerConfig.Load();
            _enemyConfig = _enemyConfig.Load();
            _gameConfig = _gameConfig.Load();
        }
        private void OnApplicationQuit()
        {
            _playerConfig.Save();
            _enemyConfig.Save();
            _gameConfig.Save();
        }
    }
}

