using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour {
    public Text fastTower;
    public Text normalTower;
    public Text slowTower;
    public TowerPlatformSystem towerPlatformSystem;

    void Awake() {
        fastTower.text = "Fast Tower - " + towerPlatformSystem.towerDatas.Find(t => t.type.ToString() == "FAST").cost;
        normalTower.text = "Normal Tower - " + towerPlatformSystem.towerDatas.Find(t => t.type.ToString() == "NORMAL").cost;
        slowTower.text = "Slow Tower - " + towerPlatformSystem.towerDatas.Find(t => t.type.ToString() == "SLOW").cost;
    }
}
