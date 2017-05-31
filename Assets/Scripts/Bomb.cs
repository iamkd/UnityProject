using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {
	public override void SideEffect(RabbitBehavior rabbit) {
		if (rabbit.isBig) {
			rabbit.isBig = false;
			rabbit.transform.localScale = new Vector3(1, 1, 1);
		} else {
			LevelController.current.onRabbitDeath(rabbit, true);
		}
	}
}
