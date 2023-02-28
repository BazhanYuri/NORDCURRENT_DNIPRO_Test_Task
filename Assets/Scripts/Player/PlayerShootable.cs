using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    public class PlayerShootable : Shootable
    {
        public override void SubscribeEvents()
        {
            InputManager.Shoot += Shoot;
        }
        public override void UnSubscribeEvents()
        {
            InputManager.Shoot -= Shoot;
        }

        public void Init(MonoBehaviour mono, PlayerConfig config, Transform shootPoint)
        {
            _mono = mono;
            _bulletPrefab = config.BulletPrefab;
            _coolDownTime = config.BulletCoolDown;
            _shootPoint = shootPoint;
            _bulletSpeed = config.BulletSpeed;
            _bulletDamage = config.BulletDamage;
        }

    }
}

