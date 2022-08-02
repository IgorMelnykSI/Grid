using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    [SerializeField] GameObject _selectedUnitObject, _tileObject, _unitInterface;

    void Awake(){
        Instance = this;
    }

    public void ShowTileInfo(Tile tile){
        if (tile == null){
            _tileObject.SetActive(false);
        }
        _tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        _tileObject.SetActive(true);
    }

    public void ShowSelectedUnit(BaseUnit unit){
        if (unit == null){
            _selectedUnitObject.SetActive(false);
            return;
        }
        _selectedUnitObject.GetComponentInChildren<Text>().text = unit.UnitName;
        _selectedUnitObject.SetActive(true);
        Debug.Log("selectedObj True");
    }

    public void ShowUnitInterface(BaseUnit unit) {
        if (unit == null || unit.Faction == Faction.Enemy){
            if (unit != null) {
                Debug.Log("selected unit : " + unit.Faction);
            }
            _unitInterface.SetActive(false);
            return;
        }
        _unitInterface.SetActive(true);
    }

    public void HideInterface(){
        _tileObject.SetActive(false);
        _unitInterface.SetActive(false);
        _selectedUnitObject.SetActive(false);
    }
}
