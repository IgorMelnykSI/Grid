using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;

    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _grassTile, _obstacleTile;

    private Dictionary<Vector2, Tile> _tiles;

    void Awake()
    {
        Instance = this;
    }

    public void GenarateGlobalGrid(int cellSize, Vector3 originPosition)
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++){
            for (int y = 0; y< _height; y++){
                var spawnedTile = Instantiate(_grassTile,  new Vector3(x, y) * cellSize + originPosition, Quaternion.identity);
                spawnedTile.name = $"GlobalTile {x} {y}";
                
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
        GameManager.Instance.ChangeState(GameState.SpawnHeros);
    }

    public void GenarateGrid(int cellSize, Vector3 originPosition)
    {
        for (int x = 0; x < _width; x++){
            for (int y = 0; y< _height; y++){
                var spawnedTile = Instantiate(_grassTile,  new Vector3(x, y) * cellSize + originPosition, Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                // Les cases sont des enfants de GridManager
                spawnedTile.transform.parent = gameObject.transform;
            }
        }
    }

    public void Destruction()
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public Tile GetGlobalTileAtPosition(Vector2 vector){
        if (_tiles.TryGetValue(vector, out var tile)){
            return tile;
        }
        return null;
    }

    public Tile GetHeroSpawnTile() {
        return _tiles.Where( t => t.Key.x < _width/2 && t.Value.Walkable ).OrderBy(t => Random.value).First().Value;
    }

    public Tile GetEnemySpawnTile() {
        return _tiles.Where(t => t.Key.x > _width/2 && t.Value.Walkable ).OrderBy(t => Random.value).First().Value;
    }
}
