using UnityEngine;



namespace TanksBattle
{
    public class PlayerMovement
    {
        private PlayerConfig _playerConfig;
        private Rigidbody _rigidBody;
        private Vector3 _direction;
        private Transform _visualPart;



        public void SubscribeEvents() 
        {
            InputManager.MoveButtonPressed += MoveTank;
        }
        public void UnSubscribeEvents() 
        {
            InputManager.MoveButtonPressed -= MoveTank;
        }
        public void Init(Rigidbody rb, PlayerConfig config, Transform visualPart)
        {
            _rigidBody = rb;
            _playerConfig = config;
            _visualPart = visualPart;
        }
        
        private void MoveTank(ControlSide controlSide)
        {
            switch (controlSide)
            {
                case ControlSide.Forward:
                    _direction = Vector3.forward;
                    break;
                case ControlSide.Back:
                    _direction = Vector3.back;
                    break;
                case ControlSide.Left:
                    _direction = Vector3.left;
                    break;
                case ControlSide.Right:
                    _direction = Vector3.right;
                    break;
                default:
                    _direction = Vector3.zero;
                    break;
            }
            _visualPart.rotation = Quaternion.LookRotation(_direction);
            _rigidBody.velocity = _direction * _playerConfig.Speed;
        }

    }
}

