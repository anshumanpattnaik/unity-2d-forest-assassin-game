using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float size; 
    
    public GameObject blood;

    public bool isMovingRight;
    
    void Update() {
        if(isMovingRight){
            transform.Translate(2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (size,size);
        } else{
            transform.Translate(-2 * Time.deltaTime * speed, 0,0);
            transform.localScale = new Vector2 (-size,size);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if(trigger.gameObject.CompareTag("turn")){
            if(isMovingRight){
                isMovingRight = false;
            } else{
                isMovingRight = true;
            }
        }
    }

    public void KillEnemy() {
        Instantiate (blood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}