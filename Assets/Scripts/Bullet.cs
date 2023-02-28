using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace TanksBattle
{
    [System.Serializable]
    public class Bullet : MonoBehaviour
    {
        private float _speed;
        private float _damage;





        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Damagable damagable))
            {
                damagable.GetDamage(_damage);
            }
            Destroy(gameObject);
        }





        public void Init(float speed, float damage)
        {
            _speed = speed;
            _damage = damage;
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            transform.localPosition += transform.forward * Time.deltaTime * _speed;
        }
    }
}

