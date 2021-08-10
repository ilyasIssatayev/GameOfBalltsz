using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBall : BallBehaviour
{
    private void OnEnable()
    {
        base.OnEnable();
        gameObject.tag = "ActiveBall";
        spriteRenderer.color = Color.gray;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

    }
}
