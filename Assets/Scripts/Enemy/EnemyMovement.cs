using System.Collections;
using UnityEngine;



namespace TanksBattle
{
    public enum BotAISide
    {
        Up = 1,
        Down = -1,
        Left = 2,
        Right = -2,
        Stop = 0
    }
    public class EnemyMovement
    {
        private BotAISide _currentMoveSide;

        private EnemyConfig _enemyConfig;
        private Rigidbody _rigidbody;
        private Transform _visualPart;

        private Vector3 _direction;


        public void Init(Rigidbody rigidbody, EnemyConfig enemyConfig, Transform visualPart)
        {
            _rigidbody = rigidbody;
            _enemyConfig = enemyConfig;
            _visualPart = visualPart;
        }




        public void StartMoving(MonoBehaviour mono)
        {
            mono.StartCoroutine(Moving());
            mono.StartCoroutine(ChangeSideOfMoving());
        }
        public void MirrorMovement()
        {
            _currentMoveSide = (BotAISide)((int)_currentMoveSide * -1);
            UpdateDirection();
        }
        
        private IEnumerator Moving()
        {
            while (true)
            {
                yield return null;
                MoveTank();
            }
        }
        private IEnumerator ChangeSideOfMoving()
        {
            while (true)
            {
                SetSideOfMovement();
                yield return new WaitForSeconds(_enemyConfig.TimeToChangeDirectionOfMovement.GetRandom());
            }
        }
        private void SetSideOfMovement()
        {
            _currentMoveSide = (BotAISide)Random.Range(-2, 2);

            UpdateDirection();
        }
        private void UpdateDirection()
        {
            switch (_currentMoveSide)
            {
                case BotAISide.Up:
                    _direction = Vector3.forward;
                    break;
                case BotAISide.Down:
                    _direction = Vector3.back;
                    break;
                case BotAISide.Left:
                    _direction = Vector3.left;
                    break;
                case BotAISide.Right:
                    _direction = Vector3.right;
                    break;
                default:
                    break;
            }
        }
        private void MoveTank()
        {
            if (_direction != Vector3.zero)
            {
                _visualPart.rotation = Quaternion.LookRotation(_direction);
            }

            Vector3 newVeclocity = _direction * _enemyConfig.Speed;
            newVeclocity.y = _rigidbody.velocity.y;
            _rigidbody.velocity = newVeclocity;
        }
    }
}

