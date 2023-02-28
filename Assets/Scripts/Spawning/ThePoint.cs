using System.Collections;
using UnityEngine;



namespace TanksBattle
{
    public class ThePoint
    {
        private Transform _point;
        private MonoBehaviour _mono;
        private int _timeToUnlockPoint;


        private bool _isLocked = false;


        public bool IsLocked { get => _isLocked;}



        
        public void InitPoint(Transform point, MonoBehaviour mono, int time)
        {
            _point = point;
            _mono = mono;
            _timeToUnlockPoint = time;
        }
        
        public Vector3 GetPointPos()
        {
            _mono.StartCoroutine(LockPoint());
            return _point.position;
        }
        private IEnumerator LockPoint()
        {
            _isLocked = true;
            yield return new WaitForSeconds(_timeToUnlockPoint);
            _isLocked = false;
        }
    }
}

