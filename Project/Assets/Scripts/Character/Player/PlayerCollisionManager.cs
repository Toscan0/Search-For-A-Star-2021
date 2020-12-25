using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerCollisionManager : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = GetComponent<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);

            playerManager.GoldPickedUp();
        }
    }
}
