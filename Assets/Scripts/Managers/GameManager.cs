using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

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
                break;
            case GameState.EnemiesTurn:
                break;
            default:
                Debug.Log("Out of range Exception");
                break;
                //throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
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
