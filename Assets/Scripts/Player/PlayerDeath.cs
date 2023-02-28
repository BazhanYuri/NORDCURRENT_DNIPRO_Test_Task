using System;
using UnityEngine;



namespace TanksBattle
{
    public class PlayerDeath
    {
        private Damagable _damagable;

        public static event Action PlayerDied;


        public void SubscribeEvents()
        {
            _damagable.Dead += OnDied;
        }
        public void UnSubscribeEvents()
        {
            _damagable.Dead -= OnDied;
        }


        public void Init(Damagable damagable)
        {
            _damagable = damagable;
        }
        
        private void OnDied()
        {
            PlayerDied?.Invoke();
        }
    }
}

