using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;

    // for Online
    public Boolean viewIsMine = false;

    public HeralthBarScript healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;

    protected int dammage = 0;
    public Transform impactPoint;

    public Vector3 movePoint;
    public float moveSpeed = 25f;

    public int actionPoints = 6;

    void Update() {
        if (viewIsMine)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        }
    }

    public void TakeDammage(int dammage)
    {
        currentHealth -= dammage;
        healthBar.SetHealth(currentHealth);
    }

    public int GetUnitDammage(){
        return dammage;
    }

    public virtual void PlayFireAnimation(Transform target){
        //animator.SetBool("Fire", true);
        animator.SetTrigger("FireTrigger");
    }

    public virtual void PlayImpactAnimation()
    {

    }

}
