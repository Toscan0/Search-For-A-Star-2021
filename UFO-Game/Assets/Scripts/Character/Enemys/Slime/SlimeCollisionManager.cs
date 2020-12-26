using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlimeManager))]
[RequireComponent(typeof(SlimeMovement))]
public class SlimeCollisionManager : MonoBehaviour
{
    private SlimeManager slimeManager;
    private SlimeMovement slimeMovement;

    private void Awake()
    {
        slimeManager = GetComponent<SlimeManager>();
        slimeMovement = GetComponent<SlimeMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        slimeManager.CollisionWithPlayer(collision.gameObject);

        slimeMovement.BackgroundCollision();
    }
}
