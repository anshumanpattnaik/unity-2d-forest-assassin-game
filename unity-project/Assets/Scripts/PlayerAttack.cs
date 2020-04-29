using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    private float attackTime;
	public float attackStartTime;
    
    Animator animator;

    public Transform attackPoint;
	public float attackRange;
	public LayerMask enemyLayers;

    public AudioSource swordAudioSource;

    string ATTACK = "isAttack";

    void Start()
    {
        animator = GetComponent<Animator> ();
    }

    void Update()
    {
        if(attackTime <= 0){
			if (Input.GetKeyDown(KeyCode.W)) {
				animator.SetBool (ATTACK, true);
				swordAudioSource.Play();
				
				Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                for(int i=0; i<hitEnemies.Length; i++){
                    hitEnemies[i].GetComponent<EnemyMovement>().KillEnemy(); 
                }
                attackTime = attackStartTime; 
			} else {
				animator.SetBool (ATTACK, false);
			}
		} else{
			attackTime -= Time.deltaTime;
		}
    }

    void OnDrawGizmosSelected() {
        if(attackPoint == null)
			return;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}