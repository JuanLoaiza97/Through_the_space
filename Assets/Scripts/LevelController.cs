using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class LevelController : MonoBehaviour
{
    public Spaceship spaceShip;
    public GameObject portal;
    public bool isEnabled = true;
    public int level;

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

    private AudioClip music;

    private void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        levelProgressBar.UpdateBar(0, 1);
        spaceShip.points = SoundController.instance.score;
        scoreIndicator.UpdateIndicator(spaceShip.points);
        SoundController.instance.ResetVolumeBackgroundMusic();

        if (!isEnabled)
        {
            spawnObject.SetActive(false);
        }

        if (level == 1)
        {
            music = SoundController.instance.niviru5003;
        }
        else if (level == 2)
        {
            music = SoundController.instance.tezno1789;
        }
        else if (level == 3)
        {
            music = SoundController.instance.pixelon1902;
        }
        else if (level == 4)
        {
            music = SoundController.instance.gabrielon;
        }

        if (level == 4)
        {
            SoundController.instance.SetBackgroundMusic(music);
        }
    }

    private void Update()
    {

        //RNF2 Cuenta el tiempo y cuando pase el tiempo programado finaliza el nivel
        if (isEnabled)
        {
            time += Time.deltaTime;
            levelProgressBar.UpdateBar(time, timeToFinishedLevel);
            if (!isFinishedLevel && time > timeToFinishedLevel)
            {
                isFinishedLevel = true;
                FinishLevel();
            }
        }
    }

    //RT2 (Boton pausa)
    public void PauseLevel()
    {
        SoundController.instance.PlayButtonSound();
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
        SoundController.instance.SetBackgroundMusic(SoundController.instance.menuMusic);
    }

    //RT2 (Boton continuar)
    public void ResumeLevel()
    {
        SoundController.instance.PlayButtonSound();
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
        SoundController.instance.SetBackgroundMusic(music);
    }

    public void GameOver(int points)
    {
        SoundController.instance.StopBackgroundMusic();
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
        pointsText.text = points + " puntos";
    }

    public void RetryLevel()
    {
        SoundController.instance.PlayButtonSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ExitLevel()
    {
        SoundController.instance.PlayButtonSound();
        SceneManager.LoadScene("Menu");
    }


    public void FinishLevel()
    {
        SoundController.instance.TurnDownBackgroundMusic();
        spawnObject.SetActive(false);
        // RNT1 Si al finalizar el nivel tiene más del 80% de vida gana 20 puntos, si no gana 10
        spaceShip.points += Mathf.Round(spaceShip.currentLife / spaceShip.life) >= 80 ? 20 : 10;
        UpdateScoreIndicator();
        //RF5 Generar portal
        Invoke("InstantiatePortal", 3);
    }

    private void InstantiatePortal()
    {
        Instantiate(portal, new Vector3(13, 0, 1), gameObject.transform.rotation);
    }

    public void UpdateScoreIndicator()
    {
        scoreIndicator.UpdateIndicator(spaceShip.points);
    }

    public void NextLevel()
    {
        SoundController.instance.score = spaceShip.points;
        int nextLevel = (level + 1) % 5;
        SceneManager.LoadScene(nextLevel);
    }
}
