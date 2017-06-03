using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Orc : MonoBehaviour {

	public Vector2 patrolPointA, patrolPointB;
	public float speed = 10f;

	protected bool isMovingToB, isPatrolling;
	protected Rigidbody2D rigidBody = null;
	protected SpriteRenderer sr = null;
	protected Animator animator = null;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
		isPatrolling = true;
		isMovingToB = true;
	}
	
	// Update is called once per frame
	void Update () {
		Patrol();

		var player = FindPlayer();

		if (player != null) {
			isPatrolling = false;
			Attack(player);
		} else {
			isPatrolling = true;
		}
	}

	bool NearlyEquals(float x1, float x2) {
		return Mathf.Abs(x1 - x2) < 0.1;
	}

	void Patrol() {
		if (!isPatrolling) {
			animator.SetFloat("AbsSpeed", 0);
			return;
		}

		if (isMovingToB) {
			rigidBody.MovePosition(Vector2.MoveTowards(rigidBody.position, patrolPointB, Time.deltaTime * speed));
			sr.flipX = true;
			if (NearlyEquals(rigidBody.position.x, patrolPointB.x)) {
				isMovingToB = false;
			}
		} else {
			rigidBody.MovePosition(Vector2.MoveTowards(rigidBody.position, patrolPointA, Time.deltaTime * speed));
	  	sr.flipX = false;
			if (NearlyEquals(rigidBody.position.x, patrolPointA.x)) {
				isMovingToB = true;
			}
		}


		animator.SetFloat("AbsSpeed", speed);
	}

	protected abstract RabbitBehavior FindPlayer();
	protected abstract void Attack(RabbitBehavior player);
}
