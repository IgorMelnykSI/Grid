using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankV1 : BaseHero
{

    private const int DAMMAGE = 25; // Damagge of this precise unit

    public GameObject _impact;

    void Start()
    {
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
        this.dammage = DAMMAGE;
    }

    public override void PlayFireAnimation(Transform target)
    {
        animator.SetTrigger("FireTrigger");
        Instantiate(_impact, target.position, target.rotation);
    }

    public override void PlayImpactAnimation()
    {
        // TO DO
    }

}
