using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealthSystem : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;
    
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        
    }
}
