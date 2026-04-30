using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHealthSystem : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public float health, maxHealth;
    private Player_controller_basic player_controller;
    
    int last_value;
    
    private void Start()
    {
        player_controller = this.GetComponent<Player_controller_basic>();
        health = player_controller.player_health;
        maxHealth = player_controller.player_health;
        last_value = player_controller.player_health;
        
    }

    public void update()
    {
        if(player_controller.player_health != last_value)
        {
          OnPlayerDamaged?.Invoke();  
        }
        
       
        
        if (health <= 0)
        {
            health = 0;
            Debug.Log("you're dead");
            OnPlayerDeath?.Invoke();
        }
    }
}
