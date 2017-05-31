using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableGem : Collectable {
	public override void SideEffect(RabbitBehavior rabbit) {
    if (!rabbit.score.ContainsKey("gems")) {
      rabbit.score["gems"] = 0;
    }
    rabbit.score["gems"] += 1;
  }
}
