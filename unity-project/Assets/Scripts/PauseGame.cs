using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pausedGame;

    public void pauseGame () {
        pausedGame.SetActive(true);
    }
}
