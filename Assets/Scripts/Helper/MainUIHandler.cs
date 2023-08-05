using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    public static MainUIHandler Instance;


    private void Awake()
    {
        Instance = this;

        // putting the best player name in the top text
        UpdateTopPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateTopPlayer()
    {
        Debug.Log($"Reached + {DataFlow.Instance.bestName} + {DataFlow.Instance.bestScore}");
        if (DataFlow.Instance != null)
            bestScoreText.text = "BestScore: " + DataFlow.Instance.bestName + ":" + DataFlow.Instance.bestScore;
    }


}
