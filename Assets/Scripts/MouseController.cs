using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    GameObject objSelected = null;
    public GridManager gridManager;
    public UnitInterface unitInterface;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckHitObject();
        }
        
    }

    public void CheckHitObject()
    {
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        if (hit2D.collider != null)
        {
            objSelected = hit2D.transform.gameObject;
        } else {
            objSelected = null;
            gridManager.Destruction();
        }

        unitInterface.generateInterface(objSelected);

        if (objSelected != null && objSelected.name == "HeroObj")
        { 
            PlayerController playerC = (PlayerController)objSelected.GetComponent<PlayerController>();
            Debug.Log("Health : " + playerC.GetHealth());
            unitInterface.showInterface();
            Vector3 offset = new Vector3(10, 10); 
            gridManager.GenarateGrid(10, playerC.transform.position - offset);
        } else {
            gridManager.Destruction();
            //unitInterface.hideInterface();
        }
    }
}
