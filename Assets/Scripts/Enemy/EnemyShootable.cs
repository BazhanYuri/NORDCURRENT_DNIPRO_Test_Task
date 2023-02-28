using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    public class EnemyShootable : Shootable
    {
        private TriggerZone _triggerZone;

        private bool _isShootDown = false;
        private bool _isCanShoot = true;




        

        public void SubscriveEvents()
        {
            _triggerZone.ZoneEntered += DetectPlayerEnter;
            _triggerZone.ZoneExited += DetectPlayerExit;
        }
        public void UnSubscriveEvents()
        {
            _triggerZone.ZoneEntered -= DetectPlayerEnter;
            _triggerZone.ZoneExited += DetectPlayerExit;
        }



        public void Init(MonoBehaviour mono, EnemyConfig config, Transform shootPoint, TriggerZone triggerZone)
        {
            _mono = mono;
            _bulletPrefab = config.BulletPrefab;
            _coolDownTime = config.BulletCoolDown;
            _shootPoint = shootPoint;
            _triggerZone = triggerZone;
            _bulletSpeed = config.BulletSpeed;
            _bulletDamage = config.BulletDamage;
        }


        private void DetectPlayerEnter(Collider collider)
        {
            if (collider.GetComponent<Player>() == true)
            {
                _mono.StartCoroutine(StartShooting());
            }
        }
        private void DetectPlayerExit(Collider collider)
        {
            if (collider.GetComponent<Player>() == true)
            {
                StopShoting();
            }
        }

        private IEnumerator StartShooting()
        {
            _isCanShoot = true;

            while (true)
            {
                yield return null;
                Shoot();
            }
        }
        private void StopShoting()
        {
            _isCanShoot = false;
        }
        protected override void Shoot()
        {
            if (_isShootDown == true)
            {
                return;
            }
            if (_isCanShoot == false)
            {
                return;
            }
            base.Shoot();
            _mono.StartCoroutine(CoolDown());
        }
        private IEnumerator CoolDown()
        {
            _isShootDown = true;
            yield return new WaitForSeconds(_coolDownTime);
            _isShootDown = false;
        }
    }
}

