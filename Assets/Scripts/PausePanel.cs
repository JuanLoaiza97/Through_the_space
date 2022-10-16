using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [Header("Options")]
    public GameObject pauseButton;

    [Header("Panels")]
    public GameObject pausePanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
