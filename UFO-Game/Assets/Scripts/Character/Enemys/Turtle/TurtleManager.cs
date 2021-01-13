using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TurtleManager : Enemy, IVictoryAnim
{
    public float XVelocity { get; set; }
    public float ZVelocity { get; set; }
    //public int CollisionDamage { get => collisionDamage; }

    private Animator animator;  

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

    private new IEnumerator Die()
    {
        base.Die();

        animator.SetTrigger("Die");

        ThrowGold(transform.position);

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
        ThrowHeart(transform.position);
    }

    public void PlayVictoryAnim()
    {
        animator.SetTrigger("Victory");
    }
}
