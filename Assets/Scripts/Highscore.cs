using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public static Highscore Instance { get; private set; }

    public int HighScore;
    public string PlayerName;
    public string PlayerNameHighscore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Debug.Log(Application.persistentDataPath);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    public void SaveHighscores()
    {
        SaveHighscore data = new()
        {
            Highscore = HighScore,
            PlayerNameHighscore = PlayerNameHighscore
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveHighscore data = JsonUtility.FromJson<SaveHighscore>(json);

            HighScore = data.Highscore;
            PlayerNameHighscore = data.PlayerNameHighscore;
        }
    }
}
