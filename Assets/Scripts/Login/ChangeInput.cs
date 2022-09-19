using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChangeInput : MonoBehaviour
{
    EventSystem system;
    
    void Start()
    {
        system = EventSystem.current;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null){
                next.Select();
            }
        }
    }
}
