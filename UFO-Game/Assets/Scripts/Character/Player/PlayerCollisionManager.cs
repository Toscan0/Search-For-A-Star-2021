using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
public class PlayerCollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IPickable pickable = other.gameObject.GetComponent<IPickable>();
        if (pickable != null)
        {
            pickable.PickMe();
        }
    }
}
