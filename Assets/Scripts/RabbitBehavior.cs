using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBehavior : MonoBehaviour {

	public float speed = 1;
	Rigidbody2D body = null;
	SpriteRenderer sr = null;

	// Use this for initialization
	void Start () {
		body = this.GetComponent<Rigidbody2D> ();
		sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		float value = Input.GetAxis("Horizontal");
		if (Mathf.Abs(value) > 0.0) {
			Vector2 vel = body.velocity;
			vel.x = value * speed;
			body.velocity = vel;
		}

		if (value > 0) {
			sr.flipX = false;
		} else if (value < 0) {
			sr.flipX = true;
		}
	}
}
