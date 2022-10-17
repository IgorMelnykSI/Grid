using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;
    private List<ScriptableUnit> _units;
    public BaseUnit SelectedHero;
    public bool MoveButton = false;
    public bool AttackButton = false;

    void Awake() {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Units").ToList();
         
    }

    public void SpawnEnemies() 
    {
        var enemiesCount = 2;

        for (int i = 0; i<enemiesCount; i++){
            var randomPrefab = GetRandomUnit<BaseEnemy>(Faction.Enemy);
            var spawnedEnemy = Instantiate(randomPrefab);
            spawnedEnemy.transform.Rotate(0f, 180f, 0f); // Mirror rotation of enemies
            var randomSpawnedTile = GridManager.Instance.GetEnemySpawnTile();

            randomSpawnedTile.SetUnit(spawnedEnemy);
        }
        // Game State
        GameManager.Instance.ChangeState(GameState.HerosTurn);
    }

    public void SpawnHeros(){
        var herosCount = 1;

        for (int i = 0; i<herosCount; i++){
            var randomPrefab = GetRandomUnit<BaseHero>(Faction.Hero);
            var spawnedHero = Instantiate(randomPrefab);
            var randomSpawnedTile = GridManager.Instance.GetHeroSpawnTile();

            randomSpawnedTile.SetUnit(spawnedHero);
        }
        // Game State
        GameManager.Instance.ChangeState(GameState.SpawnEnemies);
    }

    private T GetRandomUnit<T>(Faction faction) where T : BaseUnit {
        return (T)_units.Where(u=> u.Faction == faction).OrderBy(o => Random.value).First().UnitPrefab;
    }

    public void SetSelectedHero(BaseUnit hero){
        if (hero == null){
            SelectedHero = null;
            MenuManager.Instance.ShowSelectedUnit(hero);
            return;
        }
        SelectedHero = hero;
        MenuManager.Instance.ShowSelectedUnit(hero);
    }

    public void ActivateMove(){
        MoveButton = true;
    }
    public void ActivateAttack(){
        AttackButton = true;
    }
}
