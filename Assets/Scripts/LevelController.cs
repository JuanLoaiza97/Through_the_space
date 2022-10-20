using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Spaceship spaceShip;
    public GameObject portal;
    public string nextLevel;

    [Header("Pause panel")]
    public GameObject pausePanel;
    public GameObject pauseButton;

    [Header("Game over panel")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI pointsText;

    [Header("Indicator level")]
    public ProgressBar levelProgressBar;
    public Score scoreIndicator;

    [Header("Config level")]
    public float timeToFinishedLevel;
    public GameObject spawnObject;

    private float time = 0;
    private bool isFinishedLevel = false;

    private void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelProgressBar.UpdateBar(0, 1);
        scoreIndicator.UpdateIndicator(0);
    }

    private void Update()
    {

        //RNF2 Cuenta el tiempo y cuando pase el tiempo programado finaliza el nivel
        time += Time.deltaTime;
        levelProgressBar.UpdateBar(time, timeToFinishedLevel);
        if (!isFinishedLevel && time > timeToFinishedLevel)
        {
            isFinishedLevel = true;
            FinishLevel();
        }
    }

    //RT2 (Boton pausa)
    public void PauseLevel()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    //RT2 (Boton continuar)
    public void ResumeLevel()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void GameOver(int points)
    {   
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        pointsText.text = points + " puntos";
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Menu");
    }


    public void FinishLevel()
    {
        spawnObject.SetActive(false);
        // RNT1 Si al finalizar el nivel tiene más del 80% de vida gana 20 puntos, si no gana 10
        spaceShip.points += Mathf.Round(spaceShip.currentLife / spaceShip.life) >= 80 ? 20 : 10;
        UpdateScoreIndicator();
        //RF5 Generar portal
        Instantiate(portal, new Vector3(11, 0, 1), gameObject.transform.rotation);
    }

    public void UpdateScoreIndicator()
    {
        scoreIndicator.UpdateIndicator(spaceShip.points);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
