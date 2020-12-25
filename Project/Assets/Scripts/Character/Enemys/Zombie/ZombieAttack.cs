using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ZombieManager))]
public class ZombieAttack : MonoBehaviour
{
    [SerializeField]
    private float attackRate = 1f;

    private float attackTimer;

    private ZombieManager zombieManager;

    private void Awake()
    {
        zombieManager = GetComponent<ZombieManager>();
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;   
    }

    public void Attack(GameObject target)
    {
        if (attackTimer >= attackRate)
        {
            attackTimer = 0;
            //The zombie attack dmaage is the colison damage
            zombieManager.CollisionWithPlayer(target);
        }
    }
}
