using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntityManager : MonoBehaviour {
    #region Singleton
    public static EntityManager Instance { get; set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        onReload();

    }
    #endregion
    
    public Player Player;
    [HideInInspector]
    public BaseSystem Base;
    protected List<Tower> towers = new List<Tower>();
    public List<EnemySystem> enemies;

    public void onReload() {
        Player = new Player();
        enemies = new List<EnemySystem>();
        towers = new List<Tower>();
    }

    public Tower getTower(int id) {
        foreach (Tower t in towers) {
            if (id == t.id) {
                return t;
            }
        }
        throw new System.Exception("No tower with this id");
    }

    public void removeTower(Tower tower) {
        foreach (Tower t in towers) {
            if (tower.id == t.id) {
                towers.Remove(t);
                return;
            }
        }
    }
    public void removeEnemy(EnemySystem enemy) {
        foreach (EnemySystem e in enemies) {
            if(e != null) {
                if (enemy.enemy.id == e.enemy.id) {
                    enemies.Remove(e);
                    return;
                }
            }
        }
    }

    public void addEnemy(EnemySystem enemy) {
        enemies.Add(enemy);
    }

    private void setPrefab<T>(string tag, List<T> container) where T: Entity {
        List<GameObject> prefabs = new List<GameObject>(GameObject.FindGameObjectsWithTag(tag));
        foreach (GameObject prefab in prefabs) {
            container.Add(prefab.GetComponent<T>());
        }
    }
    private void setPrefab<T>(string tag, T container) where T: Entity {
        GameObject prefab = GameObject.FindWithTag(tag);
        container = prefab.GetComponent<T>();
    }
}