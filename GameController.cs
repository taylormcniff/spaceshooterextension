using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject playerExplosion;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    public Text winText;
    public Text whoText;

    private bool gameOver;
    private bool restart;
    private bool win;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        win = false;
        RestartText.text = "";
        GameOverText.text = "";
        winText.text = "";
        whoText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        {
            if (Input.GetKey("escape"))
                Application.Quit();
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                GameOverText.text = "Game Over!";
                RestartText.text = "Press 'F' to Restart";
                restart = true;
                win = false;
                break;
            }

            if (win)
            {
                winText.text = "You Win!";
                whoText.text = "Game Created By Taylor McNiff";
                RestartText.text = "Press 'F' to Restart";
                gameOver = false;
                restart = true;
                break;

            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            win = true;
            winText.text = "You Win!";
            whoText.text = "Game Created By Taylor McNiff";
        }
    }

    public void GameOver()
        {
            gameOver = true;
        }
}