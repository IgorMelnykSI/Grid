using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : BaseEnemy 
{
    public GameObject explosion;

    void Start(){
        this.maxHealth = 100;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
    }

    public override void PlayImpactAnimation()
    {
        Instantiate(explosion, impactPoint.position, impactPoint.rotation);
        Debug.Log("Impact position :" + impactPoint.position);
    }

}
