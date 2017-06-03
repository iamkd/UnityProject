using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Vector2 endPoint;
	public float timeout = 2;
	public float speed = 2;

	private Vector2 startPoint;
	private bool isMovingToEnd = true;
	private bool isStanding = false;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		startPoint = transform.position;
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isStanding) 
			return;
			
		if (isMovingToEnd) {
			body.MovePosition(Vector2.MoveTowards(transform.position, endPoint, Time.deltaTime * speed));
			if (body.position == endPoint)
				StartCoroutine(StartTimeout());
		} else {
			body.MovePosition(Vector2.MoveTowards(transform.position, startPoint, Time.deltaTime * speed));
			if (body.position == startPoint)
				StartCoroutine(StartTimeout());
		}
	}

	IEnumerator StartTimeout() {
		isStanding = true;
		isMovingToEnd = !isMovingToEnd;
		yield return new WaitForSeconds(timeout);
		isStanding = false;
	}
}
