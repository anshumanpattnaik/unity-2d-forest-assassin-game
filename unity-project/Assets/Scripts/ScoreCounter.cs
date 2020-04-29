using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{   
    public GameObject coinSplash;

    void OnTriggerEnter2D (Collider2D trigger)
	{	
        ScoreCounterText.amount +=10;

        Instantiate (coinSplash, transform.position, Quaternion.identity);
        Destroy (gameObject); 
	}
}