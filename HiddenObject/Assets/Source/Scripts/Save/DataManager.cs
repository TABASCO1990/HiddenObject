using System.IO;
using UnityEngine;

namespace Save
{
    public class DataManager : MonoBehaviour
    {
        private const string FileName = "dataFile.json";

        public static DataManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void Save(Data data)
        {
            string dataToSave = JsonUtility.ToJson(data);
            File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + FileName, dataToSave);
        }

        public Data Load()
        {
            Data data = new Data();

            if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + FileName))
            {
                string dataString = File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + FileName);
                data = JsonUtility.FromJson<Data>(dataString);
            }

            return data;
        }
    }
}
