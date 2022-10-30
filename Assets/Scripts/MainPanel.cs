using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Options")]
    public Slider volumeFX;
    public Slider volumeMaster;
    public Toggle mute;
    private float lastVolMaster;
    private float lastVolFX;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelSelectPanel;

    private void Awake()
    {
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);
        volumeFX.onValueChanged.AddListener(ChangeVolumeFX);
        volumeMaster.onValueChanged.AddListener(ChangeVolumeMaster);
        SoundController.instance.SetBackgroundMusic(SoundController.instance.menuMusic);
    }

    public void PlayLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetMute()
    {
        SoundController.instance.PlayButtonSound();
        if (mute.isOn)
        {
            SoundController.instance.mixer.GetFloat("VolMaster", out lastVolMaster);
            SoundController.instance.mixer.SetFloat("VolMaster", -80);
            SoundController.instance.mixer.GetFloat("VolFX", out lastVolFX);
            SoundController.instance.mixer.SetFloat("VolFX", -80);
        }
        else
        SoundController.instance.mixer.SetFloat("VolMaster", lastVolMaster);
        SoundController.instance.mixer.SetFloat("VolFX", lastVolFX);
    }

    public void OpenPanel(GameObject panel)
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelSelectPanel.SetActive(false);

        panel.SetActive(true);
        SoundController.instance.PlayButtonSound();
    }

    public void ChangeVolumeMaster(float v)
    {
        SoundController.instance.mixer.SetFloat("VolMaster", v);
    }

    public void ChangeVolumeFX(float v)
    {
        SoundController.instance.mixer.SetFloat("VolFX", v);
    }
}
