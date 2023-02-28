using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    public abstract class Shootable
    {
        protected Transform _shootPoint;
        protected Bullet _bulletPrefab;
        protected float _coolDownTime;
        protected MonoBehaviour _mono;

        protected float _bulletSpeed;
        protected float _bulletDamage;

        private bool _isCooldown = false;

        public virtual void SubscribeEvents()
        {
        }
        public virtual void UnSubscribeEvents()
        {
        }


        protected virtual void Shoot()
        {
            if (_isCooldown == true)
            {
                return;
            }
            Bullet bullet = Object.Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
            bullet.Init(_bulletSpeed, _bulletDamage);

            _mono.StartCoroutine(CoolDown());
        }
        private IEnumerator CoolDown()
        {
            _isCooldown = true;
            yield return new WaitForSeconds(_coolDownTime);
            _isCooldown = false;
        }
    }
}

