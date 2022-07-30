using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : BaseEnemy 
{
    void Start(){
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
    }
    
}
