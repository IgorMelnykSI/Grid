using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInterface : MonoBehaviour
{
    [SerializeField] private GameObject _unitInterface;

    // probablement pas utile
    public void generateInterface(GameObject playerUnity)
    {
        if (playerUnity == null || playerUnity.name != "GameObject"){
            hideInterface();
        } else {
            PlayerController playerC = (PlayerController)playerUnity.GetComponent<PlayerController>();
            if (!playerC.isInit){
                Instantiate(_unitInterface, playerUnity.transform.position, Quaternion.identity);
                playerC.isInit = true;
            }
            hideInterface();
        }
    }

    public void showInterface(){
        _unitInterface.SetActive(true);
    }

    public void hideInterface()
    {
        _unitInterface.SetActive(false);
    }
}
