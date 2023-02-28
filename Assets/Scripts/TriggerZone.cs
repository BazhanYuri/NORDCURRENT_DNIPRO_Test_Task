using System;
using UnityEngine;



namespace TanksBattle
{
    public class TriggerZone : MonoBehaviour
    {
        public event Action<Collider> ZoneEntered;
        public event Action<Collider> ZoneExited;

        private void OnTriggerEnter(Collider other)
        {
            ZoneEntered?.Invoke(other);
        }
        private void OnTriggerExit(Collider other)
        {
            ZoneExited?.Invoke(other);
        }
    }
}

