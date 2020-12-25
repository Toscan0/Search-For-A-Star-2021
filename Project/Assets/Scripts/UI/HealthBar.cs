using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    private Slider healthBar;

    private void Awake()
    {
        healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        PlayerManager.OnMaxHealthUpdated += SetMaxHealth;
        PlayerManager.OnHealthUpdated += SetHealth;
    }

    private void SetMaxHealth(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
    }

    private void SetHealth(int health)
    {
        healthBar.value = health;
    }   

    private void OnDisable()
    {
        PlayerManager.OnMaxHealthUpdated -= SetMaxHealth;
        PlayerManager.OnHealthUpdated -= SetHealth;
    }
}
