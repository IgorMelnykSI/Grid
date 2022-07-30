using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private MGrid grid;

    private void Start()
    {
        grid = new MGrid(4, 3, 10f, new Vector3(-20, -20 ));
    }

    private void Update(){
        // Left mouse botton
        if (Input.GetMouseButtonDown(0)){
            grid.SetValue( UtilsClass.GetMouseWorldPosition(), grid.GetValue( UtilsClass.GetMouseWorldPosition()) + 1);
        }
        // Right one
        if (Input.GetMouseButtonDown(1)){
            Debug.Log(grid.GetValue( UtilsClass.GetMouseWorldPosition()));
        }
    }

}
