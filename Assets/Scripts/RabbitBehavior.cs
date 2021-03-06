﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour {

	public float speed = 1;
	
	bool isGrounded = false;
	bool JumpActive = false;
	float JumpTime = 0f;
	public float MaxJumpTime = 2f; public float JumpSpeed = 2f;

	public Dictionary<string, int> score;

	public bool isBig, isDead;
	Rigidbody2D body = null;
	SpriteRenderer sr = null;
	Animator animator = null;
	Transform heroParent = null;
	public static RabbitBehavior lastRabbit = null;

	void Awake() {
		lastRabbit = this;
	}

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator> ();
		score = new Dictionary<string, int>();
		isBig = false;
		heroParent = this.transform.parent;
		LevelController.current.setStartPosition (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		float value = Input.GetAxis("Horizontal");
		if (isDead) {
			animator.SetFloat("AbsSpeed", 0);
			return;
		}
		if (Mathf.Abs(value) > 0.0) {
			Vector2 vel = body.velocity;
			vel.x = value * speed;
			if (isBig) {
				vel.x *= 1.5f;
			}
			body.velocity = vel;
		}

		animator.SetFloat("AbsSpeed", Mathf.Abs(value) * speed);

		if (value > 0) {
			sr.flipX = false;
		} else if (value < 0) {
			sr.flipX = true;
		}
	}

	void FixedUpdate() {
		Vector3 from = transform.position + Vector3.up * 0.3f; Vector3 to = transform.position + Vector3.down * 0.1f; int layer_id = 1 << LayerMask.NameToLayer ("Ground");
		
		RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);

		if(hit) {
			isGrounded = true;
			if(hit.transform != null
				&& hit.transform.GetComponent<MovingPlatform>() != null) {
				SetNewParent(this.transform, hit.transform);
			}
		} else {
			isGrounded = false;
			SetNewParent(this.transform, this.heroParent);
		}
		Debug.DrawLine (from, to, Color.red);


		if(Input.GetButtonDown("Jump") && isGrounded) {
			this.JumpActive = true; 
		}

		if(this.JumpActive) {
			//Якщо кнопку ще тримають 
			if(Input.GetButton("Jump")) {
				this.JumpTime += Time.deltaTime;
				if (this.JumpTime < this.MaxJumpTime) {
					Vector2 vel = body.velocity;
					vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime); body.velocity = vel;
				}
			} else {
				this.JumpActive = false;
				this.JumpTime = 0; 
			}
		}

		if(this.isGrounded) {
			animator.SetBool ("IsJumping", false);
		} else {
			animator.SetBool ("IsJumping", true);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Collectable")) {
			Collectable item = other.gameObject.GetComponent<Collectable>();
			item.SideEffect(this);
			DestroyObject(other.gameObject);
		}
	}

	public void SetDeath(bool dead) {
		animator.SetBool("IsDead", dead);
		isDead = dead;
		if (!dead) {
			animator.SetTrigger("Respawn");
		}
	}

	static void SetNewParent(Transform obj, Transform new_parent) { 
		if(obj.transform.parent != new_parent) {
			Vector3 pos = obj.transform.position;
			obj.transform.parent = new_parent;
			obj.transform.position = pos; 
		}
	}
}
