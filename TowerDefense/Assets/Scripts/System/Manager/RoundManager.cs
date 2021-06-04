using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {
    #region Singleton
    public static RoundManager Instance { get; set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        onReload();

    }
    #endregion

    public int wave;
    public bool isWaveOver;
    public List<GameObject> enemies;
    private GameObject enemy;
    [HideInInspector]
    public List<Vector3> spawnLocations;
    private MapWaves mapWaves;

    public void onReload() {
        spawnLocations = new List<Vector3>();
        wave = -1;
        mapWaves = Instantiate(Resources.Load<MapWaves>("Data/Maps/" + SceneManager.GetActiveScene().name));
    }

    void Update() {
        if(isWaveOver && EntityManager.Instance.enemies.Count == 0) {
            if(wave == mapWaves.waves.Length - 1) {
                PauseMenu.Instance.Victory();
            } else {
                isWaveOver = false;
                wave++;
                StartCoroutine("nextWave");
            }
        }
    }

    IEnumerator nextWave() {
        yield return new WaitForSeconds(mapWaves.waittime);
        StartCoroutine("createWave");
    }

    IEnumerator createWave() {
        if(spawnLocations.Count <= 0) {
            throw new System.Exception("No spawn points!");
        }
        int count = 0;
        foreach(EnemyWave.EnemySpawnData enemySpawnData in mapWaves.waves[wave].enemies) {
            count += enemySpawnData.count;
        }
        while(count > 0) {
            int enemyType = -1;
            while(enemyType == -1) {
                enemyType = Random.Range(0, mapWaves.waves[wave].enemies.Length);
                if(mapWaves.waves[wave].enemies[enemyType].count <= 0) {
                    enemyType = -1;
                } else {
                    mapWaves.waves[wave].enemies[enemyType].count--;
                    count--;
                }
            }
            Vector3 spawn = spawnLocations[Random.Range(0, spawnLocations.Count)];
            enemy = enemies.Find(e => e.name == mapWaves.waves[wave].enemies[enemyType].type.ToString());
            yield return new WaitForSeconds(enemy.GetComponent<EnemySystem>().enemyData.spawntime);
            Instantiate(enemy, spawn, Quaternion.identity);
        }
        isWaveOver = true;
    }

    private void getRespawnLocation() {

    }
}