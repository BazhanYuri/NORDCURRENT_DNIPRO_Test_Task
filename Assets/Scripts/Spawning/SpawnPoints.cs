using UnityEngine;



namespace TanksBattle
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPointsTransform;


        private ThePoint[] _spawnPoints;




        private void Awake()
        {
            _spawnPoints = new ThePoint[_spawnPointsTransform.Length];
            SetUpPoints();
        }

        private void SetUpPoints()
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnPoints[i] = new ThePoint();
                _spawnPoints[i].InitPoint(_spawnPointsTransform[i], this, 20);
            }
        }


        public Vector3 GetFreePoint()
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                if (_spawnPoints[i].IsLocked == false)
                {
                    return _spawnPoints[i].GetPointPos();
                }
            }

            return GetRandomPoint();
        }
        public Vector3 GetRandomPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length)].GetPointPos();
        }
    }
}

