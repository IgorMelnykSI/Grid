using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLRS : BaseHero
{
    private const int DAMMAGE = 60; // Damagge of this precise unit
    
    void Start()
    {
        this.maxHealth = 80;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
        this.dammage = DAMMAGE;
    }

    public override void PlayFireAnimation()
    {
        //animator.SetBool("Fire", true);
        animator.SetTrigger("SelectionTrigger");
    }

}
