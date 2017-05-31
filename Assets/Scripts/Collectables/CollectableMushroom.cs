using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMushroom : Collectable {
	public override void SideEffect(RabbitBehavior rabbit) {
    if (rabbit.isBig)
      return;

    rabbit.isBig = true;
    rabbit.transform.localScale = new Vector3(1.5f, 1.5f, 1);
  }
}
