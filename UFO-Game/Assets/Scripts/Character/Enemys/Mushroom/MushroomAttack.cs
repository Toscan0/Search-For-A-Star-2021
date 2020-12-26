using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MushroomManager))]
[RequireComponent(typeof(Animator))]
public class MushroomAttack : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 5;
    [Tooltip("The time it will take to the bullet hit is target")]
    [SerializeField]
    private float attackSpeed = 1f;
    [SerializeField]
    private float attackRate = 5f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Rigidbody bulletPrefab;

    private float attackTimer;

    private MushroomManager mushroomManager;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mushroomManager = GetComponent<MushroomManager>();
    }

    private void Update()
    {
        // Rotate to target
        Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);

        attackTimer += Time.deltaTime;
        Attack();
    }

    private void Attack()
    {
        if (attackTimer >= attackRate)
        {
            attackTimer = 0;
            animator.SetTrigger("Attack");
        }
    }

    // Called by the animation
    private void ThrowThreeBullets()
    {
        int offset = UnityEngine.Random.Range(1, 6);

        ThrowBullet(target.position);
        ThrowBullet(target.position - new Vector3(offset, 0, 0));
        ThrowBullet(target.position + new Vector3(offset, 0, 0));
    }

    private void ThrowBullet(Vector3 targetPos)
    {
        Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.velocity = CalculateVelocity(targetPos, shootPoint.position, attackSpeed);
        bullet.GetComponent<RoundBullet>().Damage = attackDamage;
    }

    private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        // distance
        Vector3 dist = target - origin;
        Vector3 distX = dist;
        distX.y = 0f;

        // Vx = V0 * t
        float Vx = distX.magnitude / time;
        // vy = Vy * t -0.5 *  g * t
        float Vy = dist.y / time + 0.5f * Math.Abs(Physics.gravity.y) * time;

        Vector3 res = distX.normalized;
        res *= Vx;
        res.y = Vy;

        return res;
    }
}
