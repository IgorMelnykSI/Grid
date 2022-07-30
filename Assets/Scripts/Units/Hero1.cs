using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : BaseHero
{
    private const int DAMMAGE = 25; // Damagge of this precise unit

    void Start(){
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
        this.dammage = DAMMAGE;
    }

}
