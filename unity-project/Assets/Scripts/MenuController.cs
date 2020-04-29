using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{   
    public GameObject menuGameObject;
    public GameObject loadingGameObject;
    public GameObject settingsGameObject;
    public GameObject helpGameObject;

    public Slider slider;

    public AudioMixer audioMixer;
    public AudioSource bgAudioSource;

    string VOLUME = "volume";

    void Start () {
        slider.value = PlayerPrefs.GetFloat(VOLUME);
    }

    public void PlayGame() {
        bgAudioSource.Stop();
        
        menuGameObject.SetActive(false);
        loadingGameObject.SetActive(true);

        Invoke("LoadScene",5f);
    }

    public void GetHelp() {
        menuGameObject.SetActive(false);
        helpGameObject.SetActive(true);
    }

    public void Settings() {
        menuGameObject.SetActive(false);
        settingsGameObject.SetActive(true);
    }

    public void GoBack() {
        helpGameObject.SetActive(false);
        menuGameObject.SetActive(true);
    }

    public void SettingsBack() {
        settingsGameObject.SetActive(false);
        menuGameObject.SetActive(true);
    }

    public void SetVolume (float volume) {
        PlayerPrefs.SetFloat(VOLUME, slider.value);
        audioMixer.SetFloat(VOLUME, volume);
    }

    void LoadScene(){
        Application.LoadLevel("GameScene");
    }
}