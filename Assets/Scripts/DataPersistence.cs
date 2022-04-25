using System;
using System.IO;
using UnityEngine;


[Serializable]
public class HighScoreData
{
    public string name;
    public int score;

    public bool IsEmpty()
    {
        // Minimum effort
        return name == "" && score == 0;
    }
}

public class DataPersistence : MonoBehaviour
{
    private string saveFilePath;

    public static DataPersistence Instance;

    public string playerName;
    public HighScoreData highScoreData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        saveFilePath = Application.persistentDataPath + "/savefile.json";
        DontDestroyOnLoad(gameObject);
        
        LoadPersistentData();
    }

    [Serializable]
    class SaveData
    {
        public HighScoreData HighScore;
    }

    public void SavePersistentData()
    {
        SaveData data = new SaveData
        {
            HighScore = highScoreData
        };

        string dataInJson = JsonUtility.ToJson(data);
        
        File.WriteAllText(saveFilePath, dataInJson);
    }

    private void LoadPersistentData()
    {
        if (File.Exists(saveFilePath))
        {
            string rawJson = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(rawJson);

            highScoreData = data.HighScore;
        }
    }
}

