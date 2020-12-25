using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScorpionMovement : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 2f;
    public float MoveTime { get { return moveTime; } }


    public void Move()
    {
        Vector3 newPos = RandomNavMeshPosition(transform.position, 5, NavMesh.AllAreas);
        newPos.y = transform.position.y;
        transform.position = newPos;
    }

    private static Vector3 RandomNavMeshPosition(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
