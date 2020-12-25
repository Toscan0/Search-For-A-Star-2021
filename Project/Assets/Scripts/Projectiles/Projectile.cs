using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile: MonoBehaviour 
{
    public int Damage { get; set; }

    protected void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);

        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}
