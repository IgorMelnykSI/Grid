using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public string UnitName;
    public Tile OccupiedTile;
    public Faction Faction;

    public HeralthBarScript healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;

    protected int dammage = 0;

    public Vector3 movePoint;
    public float moveSpeed = 25f;

    void Update() {
        transform.position = Vector3.MoveTowards( transform.position , movePoint, moveSpeed*Time.deltaTime);
    }

    public void TakeDammage(int dammage)
    {
        currentHealth -= dammage;
        healthBar.SetHealth(currentHealth);
    }

    public int GetUnitDammage(){
        return dammage;
    }

    public virtual void PlayFireAnimation(){
        //animator.SetBool("Fire", true);
        animator.SetTrigger("FireTrigger");
    }
}
