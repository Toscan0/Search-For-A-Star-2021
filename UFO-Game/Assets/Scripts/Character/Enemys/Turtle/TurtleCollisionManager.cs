using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurtleManager))]
[RequireComponent(typeof(TurtleMovement))]
public class TurtleCollisionManager : MonoBehaviour
{
    private TurtleManager turtleManager;
    private TurtleMovement turtleMovement;

    private void Awake()
    {
        turtleManager = GetComponent<TurtleManager>();
        turtleMovement = GetComponent<TurtleMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        turtleManager.CollisionWithPlayer(collision.gameObject);

        turtleMovement.BackgroundCollision();
    }
}
