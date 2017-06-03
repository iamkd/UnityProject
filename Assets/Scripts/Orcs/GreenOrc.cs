using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : Orc
{
  protected override void Attack(RabbitBehavior player) { 
		if (Vector2.Distance(player.transform.position, rigidBody.position) < 1.5) {
			animator.SetTrigger("Attack");
			LevelController.current.onRabbitDeath(player, true);
			return;
		}

    rigidBody.MovePosition(
			Vector2.MoveTowards(rigidBody.position, new Vector2(player.transform.position.x, rigidBody.position.y), 
			Time.deltaTime * speed * 2f)
		);

		if (rigidBody.position.x < player.transform.position.x) {
			sr.flipX = true;
		} else {
			sr.flipX = false;
		}
  }

  protected override RabbitBehavior FindPlayer()
  {
    if (IsPlayerInBounds() && !RabbitBehavior.lastRabbit.isDead)
    {
      return RabbitBehavior.lastRabbit;
    }
    return null;
  }

  bool IsPlayerInBounds()
  {
    var playerPosition = RabbitBehavior.lastRabbit.transform.position;
    return playerPosition.x > Mathf.Min(patrolPointA.x, patrolPointB.x)
        && playerPosition.x < Mathf.Max(patrolPointA.x, patrolPointB.x);
  }
}
