using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;
    public InGameUI gameUI;
   
    
    private void Start()
    {
        health += maxHealth;
        gameUI = FindAnyObjectByType<InGameUI>();
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0f;
            gameUI.GameOverScreen(true);
            Destroy(gameObject);
            
        }
    }
  
}
