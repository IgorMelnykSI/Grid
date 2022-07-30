using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable; 

    public string TileName;
    public BaseUnit OccupiedUnit = null;
    public bool Walkable => _isWalkable && OccupiedUnit == null; 
     

    void OnMouseEnter(){
        _highlight.SetActive(true);
    }

    void OnMouseExit(){
        _highlight.SetActive(false);
    }

    // When Tile is clicked
    void OnMouseDown(){
        if (GameManager.Instance.GameState != GameState.HerosTurn) return;

        if (OccupiedUnit != null){
            if (OccupiedUnit.Faction == Faction.Hero){
                UnitManager.Instance.SetSelectedHero(OccupiedUnit);
            }
            // Attack
            if (UnitManager.Instance.SelectedHero != null && UnitManager.Instance.AttackButton == true){
                OccupiedUnit.TakeDammage(UnitManager.Instance.SelectedHero.GetUnitDammage());
                UnitManager.Instance.AttackButton = false;
                Debug.Log("unit : " + OccupiedUnit + " will take " + UnitManager.Instance.SelectedHero.GetUnitDammage());
                UnitManager.Instance.SelectedHero.PlayFireAnimation();
            }
        } else {
            // Move
            if (UnitManager.Instance.SelectedHero != null && UnitManager.Instance.MoveButton == true){
                SetUnit(UnitManager.Instance.SelectedHero);
                UnitManager.Instance.MoveButton = false;
            }

            UnitManager.Instance.SetSelectedHero(null);
            MenuManager.Instance.ShowUnitInterface(null);
            return;
        }

        // UI
        UnitManager.Instance.MoveButton = false;
        UnitManager.Instance.AttackButton = false;
        MenuManager.Instance.ShowTileInfo(this);
        MenuManager.Instance.ShowUnitInterface(OccupiedUnit);

    }

    public void SetUnit (BaseUnit unit) {
        if (unit.OccupiedTile != null){
            unit.OccupiedTile.OccupiedUnit = null;
        }
        //Deplacement
        if (GameManager.Instance.GameState == GameState.HerosTurn){

            Debug.Log("Actual pos : " + unit.transform.position);
            Debug.Log("Next pos : " + transform.position);
            unit.movePoint = transform.position;
        } else {
            unit.movePoint = transform.position;
            unit.transform.position = transform.position;
        }
        
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
}
