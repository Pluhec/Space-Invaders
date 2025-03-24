using System;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 20;

    private void Update()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Hracovo score" + score);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        
    }
    
}
