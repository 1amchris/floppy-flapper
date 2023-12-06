using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI scoreTextmesh;
    public GameObject gameOverScreen;

    public float speedIncreasePerMinute = 1f;
    public float timeToResetUsingJump = 0.2f;

    public float PlayerSpeed { get; set; } = 5;
    public int PlayerScore { get; private set; } = 0;
    public DateTime? PlayerDiedAt { get; private set; }
    public bool PlayerIsAlive => PlayerDiedAt is null;

    public void Update()
    {
        if (PlayerIsAlive)
        {
            PlayerSpeed += speedIncreasePerMinute / 60 * Time.deltaTime;
        }
        else
        {
            var playerDiedRecently = PlayerDiedAt > DateTime.UtcNow.AddSeconds(-timeToResetUsingJump);
            if (!playerDiedRecently && Input.GetKeyDown(KeyCode.Space))
                ResetGame();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score = 1) {
        PlayerScore += score;
        UpdateView();
    }

    public void EndGame()
    {
        PlayerDiedAt = DateTime.UtcNow;
        PlayerSpeed = 0;
        gameOverScreen.SetActive(true);
        UpdateView();
    }

    private void UpdateView()
    {
        scoreTextmesh.text = $"Score: {PlayerScore}";
    }
}
