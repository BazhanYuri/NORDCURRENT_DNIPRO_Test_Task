using UnityEngine;



namespace TanksBattle
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _visualPart;
        [SerializeField] private Damagable _damagable;
        
        
        private PlayerMovement _movement = new PlayerMovement();
        private PlayerShootable _playerShootable = new PlayerShootable();
        private PlayerDeath _playerDeath = new PlayerDeath();

        private PlayerConfig _playerConfig;

        private bool _isInitialized = false;



        private void OnEnable()
        {
            if (_isInitialized == false)
            {
                return;
            }
            SubscribeEvents();
        }
        private void OnDisable() 
        {
            _movement.UnSubscribeEvents();
            _playerShootable.UnSubscribeEvents();
            _playerDeath.UnSubscribeEvents();
        }





        public void Init(PlayerConfig playerConfig)
        {
            _playerConfig = playerConfig;
            InitPlayer();
        }

        
        private void InitPlayer()
        {
            _movement.Init(_rigidbody, SaveConteiner.Instance.PlayerConfig, _visualPart);
            _playerShootable.Init(this, SaveConteiner.Instance.PlayerConfig, _shootPoint);
            _playerDeath.Init(_damagable);

            _isInitialized = true;

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _movement.SubscribeEvents();
            _playerShootable.SubscribeEvents();
            _playerDeath.SubscribeEvents();
        }
    }
}

