using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 25f;
    public Transform movePoint;
    public MGrid grid;
    public HeralthBarScript healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    public bool isInit = false;
    
    void Start()
    {
        movePoint.parent = null;
        //grid = new MGrid(4, 3, 10f, new Vector3(-20, -20 ));
        currentHealth = 80;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        /*
        transform.position = Vector3.MoveTowards( transform.position , movePoint.position, moveSpeed*Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Input.GetMouseButtonDown(0)){
                Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
                int x = grid.GetX(mousePosition);
                int y = grid.GetY(mousePosition);
                float cellSize = grid.GetCellSize();
                // Deplacement only when click was done inside the grid
                if (grid.GetValue(x, y) != -1){
                    movePoint.position = grid.GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * .5f;
                    TakeDammage(10);
                }
            }*/

            /* Deplacement avec les touches
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") + 9, 0f, 0f);
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") + 9, 0f);
            }
        }*/
    }

    void TakeDammage(int dammage)
    {
        currentHealth -= dammage;
        healthBar.SetHealth(currentHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }


}
