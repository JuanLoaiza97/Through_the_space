using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject pointsText;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void GameOver(int points)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        //pointsText.GetComponent<Text>().text = points + " puntos";
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
