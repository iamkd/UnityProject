using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFruit : Collectable {
	public override void SideEffect(RabbitBehavior rabbit) {
    if (!rabbit.score.ContainsKey("fruits")) {
      rabbit.score["fruits"] = 0;
    }
    rabbit.score["fruits"] += 1;
  }
}
