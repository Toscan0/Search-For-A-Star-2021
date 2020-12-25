using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SkeletonManager : Enemy
{
    [SerializeField]
    private int attackDamage = 5;
    [SerializeField]
    private GameObject target;
    public GameObject Target { get { return target; } }

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        GetComponent<Collider>().enabled = true;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public void AttacksPlayer(GameObject go)
    {
        if (go.CompareTag("Player"))
        {
            var damagable = go.GetComponent<IDamagable>();
            damagable.TakeDamage(collisionDamage);
        }
    }

    private new IEnumerator Die()
    {
        base.Die();

        animator.SetTrigger("Die");

        ThrowHeart();
      
        yield return new WaitForSeconds(2.05f);

        Destroy(gameObject);
    }
}
