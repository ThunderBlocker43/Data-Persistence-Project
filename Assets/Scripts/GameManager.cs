using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string username;
    public int highscore = 0;
    
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
    public class SaveData
    {
        public string username;
        public int highscore;
    }

    public void Save()
    {
        var data = new SaveData()
        {
            username = username,
            highscore = highscore
        };

        var json = JsonUtility.ToJson(data);
        
        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void Load()
    {
        var path = Application.persistentDataPath + "/save.json";
        if (!File.Exists(path)) return;
        
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<SaveData>(json);
        
        username = data.username;
        highscore = data.highscore;
    }
}
