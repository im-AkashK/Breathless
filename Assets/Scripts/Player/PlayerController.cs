using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour{

	public float moveSpeed;

	private Rigidbody2D myRigidBody;

	private Animator myAnim;

	public GameObject bubbles;

	private bool facingRight = true; // add a variable to track the facing direction
	 public float maxOxygen = 30f; // Maximum oxygen level
    public float currentOxygen = 30f; // Current oxygen level

	// Use this for initialization
	void Start (){
		myRigidBody = GetComponent<Rigidbody2D> ();	
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update (){

		controllerManager ();
		 currentOxygen -= Time.deltaTime;

		myAnim.SetFloat ("Speed", Mathf.Abs(myRigidBody.velocity.x));
	}

	void controllerManager (){
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			if (!facingRight) { // check if facing direction changed
				Instantiate(bubbles, transform.position, Quaternion.identity);
			}
			facingRight = true;
			transform.localScale = new Vector3(1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {	
			if (facingRight) { // check if facing direction changed
				Instantiate(bubbles, transform.position, Quaternion.identity);
			}
			facingRight = false;
			transform.localScale = new Vector3(-1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Vertical") > 0f) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, moveSpeed, 0f);
		} else if (Input.GetAxis ("Vertical") < 0f) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -moveSpeed, 0f);
		}
	}

	void movePlayer(){
		if (transform.localScale.x == 1) {
			myRigidBody.velocity = new Vector3 (moveSpeed , myRigidBody.velocity.y, 0f);	
		} else {
			myRigidBody.velocity = new Vector3 (- (moveSpeed), myRigidBody.velocity.y, 0f);
		}	
	}

	public void hurt(){
		gameObject.GetComponent<Animator> ().Play ("PlayerHurt");	
		SceneManager.LoadScene("GameOver");
	}


}
