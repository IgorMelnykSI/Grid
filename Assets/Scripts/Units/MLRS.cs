using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLRS : BaseHero
{
    private const int DAMMAGE = 60; // Damagge of this precise unit

    public Transform launchPoint; // From where it will be launched
    public GameObject missileObject; // Misssile that will be launched
    
    void Start()
    {
        this.maxHealth = 80;
        this.currentHealth = maxHealth;
        this.healthBar.SetHealth(currentHealth);
        this.dammage = DAMMAGE;
    }

    public override void PlayFireAnimation(Transform target)
    {
        //animator.SetBool("Fire", true);
        animator.SetTrigger("SelectionTrigger");
        GameObject missile = Instantiate(missileObject, launchPoint.position, launchPoint.rotation);
        missile.GetComponent<MissileScript>().SetTarget(target);
    }

}
