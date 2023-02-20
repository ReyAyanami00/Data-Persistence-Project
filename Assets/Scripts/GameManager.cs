using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using System.IO;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string userName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
       public string userName;
    }
    public void Save()
    {
        SaveData Data = new SaveData();
        Data.userName = userName;
        string JSON = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + "/Savefile.Json", JSON);
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/Savefile.Json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            userName = data.userName;
        }
    }

}
