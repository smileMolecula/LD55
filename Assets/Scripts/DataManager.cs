using System.IO;
using UnityEngine;
public class DataManager : MonoBehaviour
{
    private static string Path
    {
        get{return Application.persistentDataPath + "/saveFileProgress.json";}
    }
    public DataSave dataSave;
    private void Awake()
    {
        LoadProgress();
    }
    public void SaveProgress(DataSave progressInfo)
    {
        DataSave sceneManagerUser = progressInfo;
        string data = JsonUtility.ToJson(progressInfo);
        Debug.Log(data);
        using(StreamWriter writer = new(Path,false))
        {
            writer.Write(data);
        }
    }
    public void LoadProgress()
    {
        string data;
        if(File.Exists(Path))
        {
            using(StreamReader reader = new(Path))
            {
                data = reader.ReadLine();
                Debug.Log(data);
                dataSave = JsonUtility.FromJson<DataSave>(data);
            }
        }
        else
        {
            DataSave sceneManagerUser = new DataSave();
            SaveProgress(sceneManagerUser);
        }
    }
}
