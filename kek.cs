using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rb2d;
	public float speed;
	public float jumpPower;
	bool isGrounded;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		speed = 200;
		jumpPower = 20;
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = Input.GetAxis ("Horizontal");
		bool space = Input.GetKeyDown (KeyCode.UpArrow);
		Vector2 move = new Vector2(0, rb2d.velocity.y);
		if (space && isGrounded) { 
			move.y = jumpPower;
		}
		move.x = moveX * Time.deltaTime * speed;
		rb2d.velocity = move;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log("OnCollisionEnter2d");
		isGrounded = true;
	}
	void OnCollisionExit2D (Collision2D col) {
		Debug.Log("OnCollisionExit2d");
		isGrounded = false;
	}
}

