using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject coinSplash;

    void OnTriggerEnter2D (Collider2D trigger)
	{	
        Instantiate (coinSplash, transform.position, Quaternion.identity);
        Destroy (gameObject); 
	}
}
