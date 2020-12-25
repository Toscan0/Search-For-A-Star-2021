using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.3f;
    [SerializeField]
    private int bulletSpeed = 10;
    [SerializeField]
    private int bulletDamage = 40;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private ParticleSystem muzleParticle;
    [SerializeField]
    private AudioClip shootSoundClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, gameObject.transform.rotation);

        var bulletScript = bullet.GetComponent<PlayerBullet>();
        bulletScript.Speed = bulletSpeed;
        bulletScript.Damage = bulletDamage;

        // effects
        muzleParticle.Play();
        audioSource.clip = shootSoundClip;
        audioSource.Play();
    }

    #region GET&&SET

    public float FireRate { get { return fireRate; } }
    
    #endregion
}
