using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : Collectable {
	public override void SideEffect(RabbitBehavior rabbit) {
    if (!rabbit.score.ContainsKey("coins")) {
      rabbit.score["coins"] = 0;
    }
    rabbit.score["coins"] += 1;
  }
}
