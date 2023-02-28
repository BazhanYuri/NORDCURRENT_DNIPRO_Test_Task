using UnityEngine;
using System.IO;



namespace TanksBattle
{

    public static class SaveManager
    {
        public static string Path = "/SaveData/";
        public static string FileName = "Data.txt";


        public static void Save(PlayerConfig file)
        {
            string dir = Application.persistentDataPath + Path;

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            string json = JsonUtility.ToJson(file);
            File.WriteAllText(dir + FileName, json);
        }
        public static PlayerConfig Load()
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
                Debug.Log("Save file does not exists");
            }
            return so;

        }
    }
}

