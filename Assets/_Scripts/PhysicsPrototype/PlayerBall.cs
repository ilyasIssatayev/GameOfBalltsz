using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : BallBehaviour
{

    private void OnEnable()
    {
        base.OnEnable();
        gameObject.tag = "PlayerBall";
        spriteRenderer.color = Color.white;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        //Debug.Log("Collided with " + collider);
    }
}
