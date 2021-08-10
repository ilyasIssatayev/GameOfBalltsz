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
        if(collider.CompareTag("PlayerBall"))
        {
            //Reseting selectedBall in INputHandler component
            PlayerBall playerBall = collider.GetComponent<PlayerBall>();
            PlayerBall newPlayerBall = SwitchBallType<PlayerBall>();
            newPlayerBall.inputHandler = playerBall.inputHandler;
            newPlayerBall.inputHandler.selectedBall = newPlayerBall;


            playerBall.SwitchBallType<ActiveBall>();
        }
        else if (collider.CompareTag("ActiveBall"))
        {
            SwitchBallType<ActiveBall>();
        }
    }
}
