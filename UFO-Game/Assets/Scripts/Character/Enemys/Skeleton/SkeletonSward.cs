using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonSward : MonoBehaviour
{
    private SkeletonManager skeletonManager;

    private void Awake()
    {
        skeletonManager = GetComponentInParent<SkeletonManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        skeletonManager.AttacksPlayer(collision.gameObject);
    }
}