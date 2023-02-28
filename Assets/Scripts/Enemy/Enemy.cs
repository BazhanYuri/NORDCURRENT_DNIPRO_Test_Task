using UnityEngine;



namespace TanksBattle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Transform _visualPart;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private TriggerZone _shootTrigerZone;
        [SerializeField] private Damagable _damagable;


        private EnemyShootable _enemyShootable = new EnemyShootable();
        private EnemyMovement _movement = new EnemyMovement();
        private EnemyDeath _enemyDeath = new EnemyDeath();

        private EnemyConfig _enemyConfig;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "mirrorable")
            {
                _movement.MirrorMovement();
            }
        }
        



        private void OnDisable()
        {
            _enemyShootable.UnSubscriveEvents();
            _enemyDeath.UnSubscribeEvents();
        }




        public void Init(EnemyConfig enemyConfig)
        {
            _enemyConfig = enemyConfig;
            InitEnemy();
        }


       
        private void Start()
        {
            _movement.StartMoving(this);
        }
        private void InitEnemy()
        {
            _enemyShootable.Init(this,_enemyConfig,_shootPoint, _shootTrigerZone);
            _movement.Init(_rigidbody, _enemyConfig, _visualPart);
            _enemyDeath.Init(this, _damagable);

            _enemyShootable.SubscriveEvents();
            _enemyDeath.SubscribeEvents();

        }
    }
}

