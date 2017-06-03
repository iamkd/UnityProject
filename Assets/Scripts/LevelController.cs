using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	Vector3 startingPosition;
	
	void Awake() { 
		current = this;
	}

	public void setStartPosition(Vector3 pos) { 
		this.startingPosition = pos;
	}

	public void onRabbitDeath(RabbitBehavior rabbit, bool withAnim) {
		rabbit.SetDeath(true);
		rabbit.transform.position = this.startingPosition;
		rabbit.SetDeath(false);
	  StartCoroutine(RabbitDeath(rabbit, withAnim));
	}
	IEnumerator RabbitDeath(RabbitBehavior rabbit, bool withAnim) {
		yield return new WaitForSeconds(withAnim ? 2 : 0);
	}
}
