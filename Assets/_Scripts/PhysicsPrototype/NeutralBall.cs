using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralBall : BallBehaviour
{
    private void OnEnable()
    {
        base.OnEnable();
        gameObject.tag = "NeutralBall";
        spriteRenderer.color = Color.yellow;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Debug.Log("Collided with " + collider.tag);

        if(collider.CompareTag("PlayerBall"))
        {
            SwitchBallType<PlayerBall>();
        }
    }
}
