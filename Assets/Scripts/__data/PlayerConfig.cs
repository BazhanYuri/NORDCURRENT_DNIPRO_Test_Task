using System.IO;
using UnityEngine;



namespace TanksBattle
{



    [System.Serializable]
    public class PlayerConfig : SaveFile
    {
        public float Speed;
        public float BulletSpeed;
        public float BulletCoolDown;
        public float BulletDamage;

        [SerializeField] private PlayerConfig _defaultData;

        [System.NonSerialized] public Bullet BulletPrefab;




        public PlayerConfig()
        {
            FileName = "PlayerData.txt";
            LoadButtonPrefab();
        }


        public PlayerConfig Load()
        {
            string fullPath = Application.persistentDataPath + Path + FileName;
            PlayerConfig so = new PlayerConfig();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                so = JsonUtility.FromJson<PlayerConfig>(json);
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

        private void SetDefaultData(PlayerConfig playerConfig)
        {
            playerConfig.Speed = Speed;
            playerConfig.BulletSpeed = BulletSpeed;
            playerConfig.BulletCoolDown = BulletCoolDown;
            playerConfig.BulletDamage = BulletDamage;
            LoadButtonPrefab();
        }
        private void LoadButtonPrefab()
        {
            BulletPrefab = Resources.Load("Bullet", typeof(Bullet)) as Bullet;
        }

    }
}

