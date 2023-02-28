using System.IO;
using UnityEngine;

namespace TanksBattle
{

    [System.Serializable]
    public abstract class SaveFile
    {
        protected string FileName = "Data.txt";
        protected readonly string Path = "/SaveData/";



        public virtual void Save()
        {
            string dir = Application.persistentDataPath + Path;

            if (Directory.Exists(dir) == false)
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(dir + FileName, Write(dir));
        }
        protected virtual string Write(string dir)
        {
            return JsonUtility.ToJson(this);
        }
    }
}

