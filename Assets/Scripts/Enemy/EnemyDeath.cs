using System;
using UnityEngine;
using DG.Tweening;



namespace TanksBattle
{
    public class EnemyDeath : MonoBehaviour
    {
        private Enemy _enemy;
        private Damagable _damagable;

        public static event Action EnemyDied;


        
        public void SubscribeEvents()
        {
            _damagable.Dead += Died;
        }
        public void UnSubscribeEvents()
        {
            _damagable.Dead -= Died;
        }




        public void Init(Enemy enemy, Damagable damagable)
        {
            _enemy = enemy;
            _damagable = damagable;
        }
        private void Died()
        {
            EnemyDied?.Invoke();
            VisualDeath();
        }
        private void VisualDeath()
        {
            _enemy.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f, 1).OnComplete(() => Destroy(_enemy.gameObject));
        }

    }
}

