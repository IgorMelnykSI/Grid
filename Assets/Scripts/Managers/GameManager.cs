using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    // default faction or current player faction (à voir si utile)
    public Faction PlayerFaction = Faction.Hero;
    // Faction of current playing player
    public Faction TurnFaction = Faction.Hero;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.GenerateGlobalGrid);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGlobalGrid:
                GridManager.Instance.GenarateGlobalGrid(10, new Vector3(-20, -5, 0));
                break;
            case GameState.SpawnHeros:
                UnitManager.Instance.SpawnHeros();
                break;
            case GameState.SpawnEnemies:
                UnitManager.Instance.SpawnEnemies();
                break;
            case GameState.HerosTurn:
                TurnFaction = Faction.Hero;
                break;
            case GameState.EnemiesTurn:
                TurnFaction = Faction.Enemy;
                PlayerFaction = Faction.Enemy; // simulation of online or local multiplayer !!
                //GameState = GameState.HerosTurn; // On revient directement sur le tour du héro 
                break;
            default:
                Debug.Log("Out of range Exception");
                break;
                //throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void NextTurn(){
        MenuManager.Instance.HideInterface();
        ChangeState(GameState.EnemiesTurn);
        UnitManager.Instance.reInitialiseActionPoints();
    }

}

public enum GameState
    {
        GenerateGlobalGrid = 0,
        SpawnHeros = 1,
        SpawnEnemies = 2,
        HerosTurn = 3,
        EnemiesTurn = 4
    }
