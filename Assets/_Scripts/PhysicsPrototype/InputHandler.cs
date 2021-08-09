using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Please, Touch")]
    public PlayerBall selectedBall;
    public InputDisplay inputDisplay;

    public int previousTouchCount = 0;
    public float forceMultiplier = 1;

    public bool isReverse = false;

    [Header("Please, Dont touch")]
    public Vector3 entryPoint;
    public Vector3 exitPoint;

    Vector3 worldPos;

    void Update()
    {
        int touchCount = Input.touchCount;
        inputDisplay.gameObject.SetActive(touchCount > 0);
        if (touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            worldPos = Camera.main.ScreenToWorldPoint(touch.position);
            worldPos.z = 0;

            inputDisplay.entryPoint.transform.position = entryPoint;
            inputDisplay.exitPoint.transform.position = worldPos;
        }


        if ( touchCount > 0 && previousTouchCount == 0)
        {
            //EntryPoint
            entryPoint = worldPos;
            inputDisplay.entryPoint.transform.position = entryPoint;
        }

        if (touchCount == 0 && previousTouchCount > 0)
        {
            //ExitPoint
            exitPoint = worldPos;
            ApplyShoot(entryPoint, exitPoint);
        }

        previousTouchCount = touchCount;
    }

    public void ApplyShoot(Vector3 pointA, Vector3 pointB)
    {
        Vector3 forceVector = pointB - pointA;
        if (isReverse) forceMultiplier *= -1;
        selectedBall.rigidbody.AddForce(forceVector*forceMultiplier);
    }

    bool IsTouched(BallBehaviour ball, Vector3 touchPosition)
    {
        return (ball.circleCollider == Physics2D.OverlapPoint(touchPosition));
    }
}
