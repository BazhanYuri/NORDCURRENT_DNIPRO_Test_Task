using System;
using UnityEngine;


namespace TanksBattle
{

    public class Damagable : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        public event Action<float> HealthUpdated; // percent
        public event Action Dead;

        private float _currentHealth;
        protected float _currentPercentOfHealth;
        protected bool _isDead = false;

        public bool IsDead { get => _isDead;}





        public void ResetHealthCompletely()
        {
            _isDead = false;
            _currentHealth = _maxHealth;
            UpdateHeatlh();
        }
        public virtual void GetDamage(float damage)
        {
            if (_isDead == true)
            {
                return;
            }

            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                InvokeDead();
                return;
            }
            UpdateHeatlh();
        }
        public void Awake()
        {
            _currentHealth = _maxHealth;
        }
        protected virtual void UpdateHeatlh()
        {
            _currentPercentOfHealth = _currentHealth / _maxHealth;
            HealthUpdated?.Invoke(_currentPercentOfHealth);
        }
        protected virtual void InvokeDead()
        {
            _isDead = true;
            UpdateHeatlh();
            Dead?.Invoke();
        }
    }
}

