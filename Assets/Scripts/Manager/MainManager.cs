using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public string username;
    public int score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadUsername();
    }


    [System.Serializable]
    class SaveData
    {
        public string username;
        public int score;
    }

    public void SaveUsername()
    {
        SaveData data = new SaveData();
        data.username = username;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + $"/savefile{data.username}.json", json);


    }

    public void LoadUsername()
    {
        string path = Application.persistentDataPath + $"/savefile{username}.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            username = data.username;
            score = data.score;
        }
    }
}
