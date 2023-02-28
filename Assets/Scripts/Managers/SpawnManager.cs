using System;
using System.Collections;
using UnityEngine;



namespace TanksBattle
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private SpawnPoints _spawnPoints;
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Enemy _enemyPrefab;

        public static event Action<Transform> PlayerSpawned;


        private Player _player;
        private GameConfig _gameConfig;
        private EnemyConfig _enemyConfig;
        private PlayerConfig _playerConfig;



        private void OnEnable()
        {
            GameManager.GamePlayStarted += StartSpawning;
            EnemyDeath.EnemyDied += SpawnEnemy;
            PlayerDeath.PlayerDied += ReswapnPlayer;
        }
        private void OnDisable()
        {
            GameManager.GamePlayStarted -= StartSpawning;
            EnemyDeath.EnemyDied -= SpawnEnemy;
            PlayerDeath.PlayerDied += ReswapnPlayer;
        }


        public void Init(GameConfig gameConfig, EnemyConfig enemyConfig, PlayerConfig playerConfig)
        {
            _gameConfig = gameConfig;
            _enemyConfig = enemyConfig;
        }
        private void StartSpawning()
        {
            SpawnPlayer();
            SpawningEnemies();
        }
        private void SpawnPlayer()
        {
            _player = Instantiate(_playerPrefab, _spawnPoints.GetFreePoint(), Quaternion.identity);
            _player.Init(_playerConfig);
            PlayerSpawned?.Invoke(_player.transform);
        }
        private void SpawningEnemies()
        {
            for (int i = 0; i < _gameConfig.CountOfEnemyOnLevel; i++)
            {
                SpawnEnemy();
            }
        }
        private void SpawnEnemy()
        {
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints.GetFreePoint(), Quaternion.identity);
            enemy.Init(_enemyConfig);
        }
        private void ReswapnPlayer()
        {
            StartCoroutine(RespawningPlayer());
        }
        private IEnumerator RespawningPlayer()
        {
            _player.gameObject.SetActive(false);
            yield return new WaitForSeconds(1);
            _player.gameObject.SetActive(true);
            _player.transform.position = _spawnPoints.GetFreePoint();
            _player.GetComponent<Damagable>().ResetHealthCompletely();
        }
    }
}

