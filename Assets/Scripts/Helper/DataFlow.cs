using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataFlow : MonoBehaviour
{
    public static DataFlow Instance;
    public TextMeshProUGUI bestScoreText;

    private string currentName;
    private int currentScore;
    public string bestName { get; private set; }
    public int bestScore { get; private set; }

private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class BestPlayer
    {
        public string bestName;
        public int bestScore;
    }

    // Called when we start the game
    public void SaveCurrentPlayerName(string name)
    {
        currentName = name;
    }

    // Called when the current player get a higher score
    public void SaveBestPlayer(int points)
    {
        BestPlayer best = new BestPlayer();
        // save the values in the object to be saved in json
        best.bestName = currentName;
        best.bestScore = points;

        // update the variables
        bestName = currentName;
        bestScore = points;

        string json = JsonUtility.ToJson(best);
        File.WriteAllText(Application.persistentDataPath + "bestPlayer.json", json);


        // Now we update everything
        MainUIHandler.Instance.UpdateTopPlayer();
    }

    // Called at the begin of the game
    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "bestPlayer.json";
        Debug.Log($"path: {path}");
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer best = JsonUtility.FromJson<BestPlayer>(json);

            bestName = best.bestName;
            bestScore = best.bestScore;
        }

        bestScoreText.SetText($"BestScore: {bestName}: {bestScore}");
    }
}
