using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerPlatformSystem : MonoBehaviour, ITowerPlatformObserver {
    public TowerSystem tower;
    public bool isEmpty = true;
    public GameObject towerHolder;
    public List<TowerData> towerDatas;
    public TowerMenuUI UI = new TowerMenuUI();

    public void onBuildNotify(TowerType towerType) {
        foreach (TowerData towerData in towerDatas) {
            if (isEmpty && towerData.type == towerType && towerData.cost <= EntityManager.Instance.Player.money) {
                tower = Factory.Instance.TowerFactory(towerType, towerHolder);
                tower.platformSystem = this;
                EntityManager.Instance.Player.pay(towerData.cost);
                UI.changeToMenu(towerType);
                isEmpty = false;
            }
        }
    }

    public void onUpgradeNotify(Effect effect) {
        if (effect.cost <= EntityManager.Instance.Player.money) {
            tower.upgrade(effect);
            UI.changeEffectDisplay(effect);
            EntityManager.Instance.Player.pay(effect.cost);
        }
    }

    public void onInteractNotify(Interaction signal) {
        UI.interaction(signal);
    }

    public void onTowerDestroyNotify() {
        tower.refundMoney();
        Destroy(tower.gameObject);
        UI.changeToBuild();
        isEmpty = true;
    }

    void Awake() {
        isEmpty = true;
    }
}