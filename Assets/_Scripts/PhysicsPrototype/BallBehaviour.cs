using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class BallBehaviour : MonoBehaviour
{

    [Header("Automatic")]
    public CircleCollider2D circleCollider;
    public Rigidbody2D rigidbody;
    public SpriteRenderer spriteRenderer;

    public void OnEnable()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    public void OnDisable()
    {
        circleCollider = null;
        rigidbody = null;
        spriteRenderer = null;
    }


    void Update()
    {

    }

    public void SwitchBallType<T> () where T : BallBehaviour
    {
        Debug.Log(tag + " switching to " + typeof(T));

        T newComponent = gameObject.AddComponent<T>();
        Destroy(this);
    }

}
