using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string Name;



    // Awake method
    private void Awake()
    {
        if(Instance != null)
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
        public int BestScore;
        public string BestName;
    }

    public void SaveBestScore(int BestScore , string BestName)
    {
        SaveData data = new SaveData();
        data.BestScore = BestScore;
        data.BestName = BestName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public SaveData LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            Debug.Log("Test");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("data: " + data.BestName + " Score: "+ data.BestScore);
            return data;

        }
        
        return null;
    }
}
