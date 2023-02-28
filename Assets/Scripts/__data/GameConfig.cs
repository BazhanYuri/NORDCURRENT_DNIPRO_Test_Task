using System.IO;
using UnityEngine;



namespace TanksBattle
{


    [System.Serializable]
    public class GameConfig : SaveFile
    {
        public int CountOfEnemyOnLevel;




        public GameConfig()
        {
            FileName = "GameConfig.txt";
        }
        public GameConfig Load()
        {
            string fullPath = Application.persistentDataPath + Path + FileName;
            GameConfig so = new GameConfig();

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                so = JsonUtility.FromJson<GameConfig>(json);
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

        private void SetDefaultData(GameConfig gameConfig)
        {
            gameConfig.CountOfEnemyOnLevel = CountOfEnemyOnLevel;
        }
    }
}

