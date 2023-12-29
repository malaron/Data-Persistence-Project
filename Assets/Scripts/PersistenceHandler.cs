using System.IO;
using UnityEngine;

public class PersistenceHandler
{
    private static int bestScore;
    private static string bestPlayer;

    public PersistenceHandler()
    {
        LoadUser();
    }

    public void update()
    {
        if (PlayerDataHandler.Instance.Score > bestScore)
        {
            bestScore = PlayerDataHandler.Instance.Score;
            bestPlayer = PlayerDataHandler.Instance.PlayerName;
            SaveUser();
        }
    }

    public string GetBestUser()
    {
        return bestPlayer;
    }

    public int GetBestScore()
    {
        return bestScore;
    }

    private void SaveUser()
    {
        SaveData data = new SaveData();

        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUser()
    {
        SaveData data;
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
            bestPlayer = data.bestPlayer;
        }
        else
        { 
            bestScore = 0;
            bestPlayer = "None";
        }

        Debug.Log("BP" + bestPlayer);
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
        public string bestPlayer;
    }
}
