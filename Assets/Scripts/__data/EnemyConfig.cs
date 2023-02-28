using System.IO;
using UnityEngine;



namespace TanksBattle
{

    [System.Serializable]
    public class Clamps
    {
        [SerializeField] private float _min;
        [SerializeField] private float _max;



        public float GetRandom()
        {
            return Random.RandomRange(_min, _max);
        }
    }

    
    [System.Serializable]
    public class EnemyConfig : SaveFile
    {
        public float Speed;
        public Clamps TimeToChangeDirectionOfMovement;
        public float BulletSpeed;
        public float BulletCoolDown;
        public float BulletDamage;


        [System.NonSerialized] public Bullet BulletPrefab;

        public EnemyConfig()
        {
            FileName = "EnemyInfo.txt";
            LoadButtonPrefab();
        }

        public EnemyConfig Load()
        {
            string fullPath = Application.persistentDataPath + Path + FileName;
            EnemyConfig so = new EnemyConfig();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                so = JsonUtility.FromJson<EnemyConfig>(json);
            }
            else
            {
                SetDefaultData(so);
            }

            return so;
        }

        protected override string Write(string dir)
        {
            return JsonUtility.ToJson(this);
        }


        private void SetDefaultData(EnemyConfig enemyConfig)
        {
            enemyConfig.Speed = Speed;
            enemyConfig.TimeToChangeDirectionOfMovement = TimeToChangeDirectionOfMovement;
            enemyConfig.BulletSpeed = BulletSpeed;
            enemyConfig.BulletCoolDown = BulletCoolDown;
            enemyConfig.BulletDamage = BulletDamage;
            LoadButtonPrefab();
        }
        private void LoadButtonPrefab()
        {
            BulletPrefab = Resources.Load("Bullet", typeof(Bullet)) as Bullet;
        }
    }
}

