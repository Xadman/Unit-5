using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// created all the variables and functions
    /// </summary>
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    private int score;
    private float spawnRate = 1.5f;
    private Button button;
    

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false; // setting Variabels and initiallizing
        score = 0;

        StartCoroutine(SpawnTarget()); // staring the spawning of the objects
       UpdateScore(0);

        
        
        }



    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {


            yield return new WaitForSeconds(spawnRate); // setting the spawn rate of the objects 
            int index = Random.Range(0, targets.Count); // setting the range to a random ammount
            Instantiate(targets[index]); // it will select targets from the array i created 
            
        }
    }
     public void UpdateScore(int scoreToAdd)
    {// this is the method to keep score
        score += scoreToAdd; 
        scoreText.text = "Score: " + score;
    }

    public void GameOver() 
    {// this is the method that checks to see if the game is active once it is not it will display game over and the restart button
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {// method to let the built in screen manager work
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {// method that will allow and change the difficulty of the game depending on which  button selected
        isGameActive = true; // setting Variabels and initiallizing
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

    }
}
