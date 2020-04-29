using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timerText;
    
    public int minutes;
    public int seconds;

    public static bool isTimeup;

    public GameObject playerObject;
    public GameObject timerObject;
    public GameObject topPanel;

    void Start()
    {   
        isTimeup = false;
        StartCoroutine (second ());
    }   

    void Update()
    {   
        if(!PlayerController.isGameOver){
            if (seconds == 0 && minutes == 0) {
                isTimeup = true;
                timerText.text = "00:00";
                StopCoroutine (second ());
                
                Destroy(topPanel);
                Destroy(playerObject);

                timerObject.SetActive(true);
            }
        }
    }

    IEnumerator second(){
        yield return new WaitForSeconds (1f);

        if(seconds > 0)
        seconds--;

        if(seconds == 0 && minutes != 0) {
            seconds = 60;
            minutes--;
        }

        if(seconds < 10)  {
            timerText.text = "0"+minutes + ":" +"0"+seconds;
        } else
        {
            timerText.text = "0"+minutes + ":" +seconds;
        }

        StartCoroutine (second ());
    }
}