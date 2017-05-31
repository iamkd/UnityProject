using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		RabbitBehavior rabbit = collider.GetComponent<RabbitBehavior> ();
		if(rabbit != null) {
			LevelController.current.onRabbitDeath(rabbit, false);
		} 
	}
}
