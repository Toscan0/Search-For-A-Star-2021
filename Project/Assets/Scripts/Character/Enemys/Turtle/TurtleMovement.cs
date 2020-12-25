using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TurtleManager))]
public class TurtleMovement : MonoBehaviour
{
    private float minVelocity = 4;
    private float maxVelocity = 6;

    private Rigidbody rb;
    private TurtleManager turtleManager;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        turtleManager = GetComponent<TurtleManager>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        turtleManager.XVelocity = Movement.RandomVelocity(minVelocity, maxVelocity);
        turtleManager.ZVelocity = Movement.RandomVelocity(minVelocity, maxVelocity);

        SetVelocity();
    }

    

    public void SetVelocity()
    {

        float xVelocity = turtleManager.XVelocity;
        float zVelocity = turtleManager.ZVelocity;

        rb.velocity = new Vector3(xVelocity, 0, zVelocity);

        // animations
        xVelocity = Movement.NumberConverter(xVelocity, minVelocity, maxVelocity, -1, 1);
        zVelocity = Movement.NumberConverter(zVelocity, minVelocity, maxVelocity, -1, 1);
        var move = new Vector3(xVelocity, zVelocity);
        move.Normalize();

        animator.SetFloat("Speed", move.sqrMagnitude);
        animator.SetFloat("MoveX", move.x);
        animator.SetFloat("MoveZ", move.y);
    }

    public void BackgroundCollision()
    {
        float xVelocity = turtleManager.XVelocity;
        float zVelocity = turtleManager.ZVelocity;

        if (transform.position.x >= 14.3 || transform.position.x <= -14.3)
        {
            xVelocity = -xVelocity;
        }
        if (transform.position.z >= 24.3 || transform.position.z <= -24.3)
        {
            zVelocity = -zVelocity;
        }

        turtleManager.XVelocity = xVelocity;
        turtleManager.ZVelocity = zVelocity;

        SetVelocity();
    }
}
