using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValue;
    public float interval;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    
    private bool gameOverSwitch = false;
    private AudioSource backgroundAudio;

    public float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        backgroundAudio = GetComponent<AudioSource>();
        backgroundAudio.Play(0);
        
    }

    void Update()
    {
        if (gameOverSwitch)
        {
            RestartGame();
        }
    }


    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x,spawnValue.x), spawnValue.y, spawnValue.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(interval);
        }
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "GAME OVER!";
        gameOverSwitch = true;
        
    }

    public void RestartGame()
    {
        restartText.text = "PRESS R TO RESTART!";

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            gameOverSwitch = false;
        }
    }
    
    
    
    
}
