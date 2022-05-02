using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;
    }

    public static MenuManager Instance;

    public string playerName;
    public string bestName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadSettings();
    }

    public void SaveSettings(int newScore)
    {
        SaveData data = new SaveData();
        if (newScore > bestScore)
        {
            bestScore = newScore;
            bestName = playerName;
        }
        data.bestName = bestName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestName = data.bestName;
            bestScore = data.bestScore;
        }
    }
}
