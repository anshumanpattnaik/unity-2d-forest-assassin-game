using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb;
	Animator animator;
	Vector3 localScale;
	
	float dirX, moveSpeed = 5f;
	float jumpForce = 600f;
	
	bool isHurting, isDead;
	bool facingRight = true;
	bool isMoving = false;
	bool isWalking = false;
	public static bool isGameOver = false;
	
	public AudioSource bgAudioSource;
	public AudioSource jumpAudioSource;
	public AudioSource runningAudioSource;
	public AudioSource coinAudioSource;

	public GameObject blood;
	public GameObject gameOver;

	public GameObject winEffect;
	public GameObject finishGame;
	public GameObject topPanel;

	string JUMPING = "isJumping";
	string WALKING = "isWalking";

	void Start () {
		ScoreCounterText.amount = 0;
		isGameOver = false;

		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		localScale = transform.localScale;
	}
	
	void Update () {
		if(!CanvasScript.isPaused) {

			if(!bgAudioSource.isPlaying){
				bgAudioSource.Play();
			}

			if (Input.GetButtonDown ("Jump") && !isDead && rb.velocity.y == 0) {
				jumpAudioSource.Play();
				rb.AddForce (Vector2.up * jumpForce);
			}

			SetAnimationState ();

			if (!isDead) {
				dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
			
				if(rb.velocity.x !=0){
					isMoving = true;
				} else{
					isMoving = false;
				}
			
				if(isMoving && isWalking){
					if(!runningAudioSource.isPlaying)
					runningAudioSource.Play();
				} else {
					runningAudioSource.Stop();
				}
			}
		} else{
			bgAudioSource.Stop();
		}
	}

	void FixedUpdate()
	{
		if (!isDead) {
			rb.velocity = new Vector2 (dirX, rb.velocity.y);
		} 
	}

	void LateUpdate()
	{
		PlayerFacePosition();
	}

	void SetAnimationState()
	{
		if (dirX == 0) {
			animator.SetBool (WALKING, false);
		}

		if (rb.velocity.y == 0) {
			animator.SetBool (JUMPING, false);
		}

		if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0) {
			isWalking = true;
			animator.SetBool (WALKING, true);
		}

		if (rb.velocity.y > 0) {
			isWalking = false;
			animator.SetBool (JUMPING, true);
		} 
		
		if(rb.velocity.y < 0){
			animator.SetBool (JUMPING, false);
		}
	}

	void PlayerFacePosition()
	{
		if (dirX > 0)
			facingRight = true;
		else if (dirX < 0)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;
	}

	void OnTriggerEnter2D (Collider2D trigger)
	{	
		if(trigger.gameObject.CompareTag("Enemy")){ 
			if(!TimerScript.isTimeup){
				isGameOver = true;
				dirX = 0;
				isDead = true;
				
				Instantiate (blood, transform.position, Quaternion.identity);
				Destroy(topPanel);
				Destroy (gameObject);

				gameOver.SetActive(true);
			}
		}

		if(trigger.gameObject.CompareTag("Finish")){ 
			isGameOver = true;
			dirX = 0;
			
			Instantiate (winEffect, transform.position, Quaternion.identity);
			Destroy(topPanel);

        	gameObject.SetActive(false);
			finishGame.SetActive(true);
		}

		if(trigger.gameObject.CompareTag("Point")){ 
			coinAudioSource.Play();
		}
	}
}