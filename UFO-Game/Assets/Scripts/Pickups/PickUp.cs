using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour, IPickable
{
    public virtual void PickMe()
    {
        Debug.Log("pick me!!");
    }
}
     
