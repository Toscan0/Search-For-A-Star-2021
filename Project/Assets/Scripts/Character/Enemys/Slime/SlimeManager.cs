using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SlimeManager : Enemy, IVictoryAnim
{
    /* Slimer only haves on vel, it walks always in a perfect diagonal, and it 
    starts walking towars the impar quadrants */
    public float Velocity { get; set; }

    [SerializeField]
    [Tooltip("How much times, slime reproduces")]
    private int numberOfInstances = 0;
    public int NumberOfInstances { set { numberOfInstances = value; } }

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

    private new IEnumerator Die()
    {
        base.Die();

        Velocity = 0;

        animator.SetTrigger("Die");
        
        if (numberOfInstances > 0)
        {
            //Create two clones
            GameObject slime1 = Instantiate(gameObject, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            slime1.GetComponent<SlimeManager>().NumberOfInstances = numberOfInstances - 1;
            GameObject slime2 = Instantiate(gameObject, transform.position - new Vector3(1, 0, 0), Quaternion.identity);
            slime2.GetComponent<SlimeManager>().NumberOfInstances = numberOfInstances - 1;
        }
        else
        {
            ThrowHeart();
        }

        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    public void PlayVictoryAnim()
    {
        animator.SetTrigger("Victory");
    }
}
