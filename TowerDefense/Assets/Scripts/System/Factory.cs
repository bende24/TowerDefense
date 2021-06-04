using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {
    #region Singleton
    public static Factory Instance { get; set; }
    private void Awake() {

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

    }
    #endregion
    public GameObject normalTowerPrefab;
    public GameObject slowTowerPrefab;
    public GameObject fastTowerPrefab;

    public TowerSystem TowerFactory(TowerType type, GameObject towerHolder) {
        GameObject t;
        switch (type) {
            case TowerType.NORMAL:
                t = Instantiate(normalTowerPrefab, towerHolder.transform.position, Quaternion.identity, towerHolder.transform);
                break;
            case TowerType.SLOW:
                t = Instantiate(slowTowerPrefab, towerHolder.transform.position, Quaternion.identity, towerHolder.transform);
                break;
            case TowerType.FAST:
                t = Instantiate(fastTowerPrefab, towerHolder.transform.position, Quaternion.identity, towerHolder.transform);
                break;
            default:
                throw new System.Exception("Wrong button parameter string.");
        }
        return t.GetComponent<TowerSystem>();
    }
}