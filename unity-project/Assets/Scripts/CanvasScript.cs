using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CanvasScript : MonoBehaviour
{   
    public static bool isPaused = false;

    bool isPauseEnable = false;
    bool isSettingsEnable = false;
    bool isHelpEnable = false;

    public GameObject pausedGame;
    public GameObject settings;
    public GameObject help;

    public Slider slider;

    public AudioMixer audioMixer;

    string VOLUME = "volume";

    void Start () {
        slider.value = PlayerPrefs.GetFloat(VOLUME);
    }

    public void Restart () {
        pausedGame.SetActive(false);
        Time.timeScale = 1f;

        isPauseEnable = false;
        isPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PauseGame () {
        if(!isSettingsEnable && !isHelpEnable){
            pausedGame.SetActive(true);
            Time.timeScale = 0f;
            
            isPauseEnable = true;
            isPaused = true;
        }
    }

    public void ResumeGame () {
        pausedGame.SetActive(false);
        Time.timeScale = 1f;

        isPauseEnable = false;
        isPaused = false;
    }

    public void MainMenu () {
        Application.LoadLevel("MainScene");
    }

    public void Settings () {
        if(!isPauseEnable && !isHelpEnable){
            isSettingsEnable = true;

            settings.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void CloseSettings () {
        settings.SetActive(false);
        Time.timeScale = 1f;

        isSettingsEnable = false;
    }

    public void Help () {
        if(!isPauseEnable && !isSettingsEnable){
            isHelpEnable = true;
            isPaused = true;

            help.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    public void CloseHelp () {
        help.SetActive(false);
        Time.timeScale = 1f;

        isHelpEnable = false;
        isPaused = false;
    }

    public void SetVolume (float volume) {
        PlayerPrefs.SetFloat(VOLUME, slider.value);
        audioMixer.SetFloat(VOLUME, volume);
    }
}