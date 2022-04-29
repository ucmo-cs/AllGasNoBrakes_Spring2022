using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private LevelManager gameLevelManager;  // retrieve coin count here.  
    public Text scoreText;
    public string score;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }
    // Update is called once per frame
    void Update()
    {
        DisplayScore(gameLevelManager.currentCoins);
    }

    void DisplayScore(string currentScore)
    {
        this.score = currentScore;
        scoreText.text = "Score: " + currentScore;
    }
}
