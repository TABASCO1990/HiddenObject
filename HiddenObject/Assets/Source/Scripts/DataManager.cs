using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Save(Data data)
    {
        string dataToSave = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json", dataToSave);
    }

    public Data Load()
    {
        Data data = new Data();

        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json"))
        {
            string dataString = File.ReadAllText(Application.persistentDataPath + Path.DirectorySeparatorChar + "dataFile.json");
            data = JsonUtility.FromJson<Data>(dataString);
        }

        return data;
    }
}
