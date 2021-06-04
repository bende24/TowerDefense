using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatformButton : MonoBehaviour, ITowerPlatformSubject {

    public GameObject parent;
    public ITowerPlatformObserver Observer { get; set; }

    /// <summary>
    /// Notifies the observer about wanting to build a tower
    /// </summary>
    /// <param name="type"> The type of the tower </param>
    public void buildNotify(string type) {
        TowerType signal;
        System.Enum.TryParse(type, out signal);
        Observer.onBuildNotify(signal);
    }

    /// <summary>
    /// Notifies the observer about wanting to upgrade a tower
    /// </summary>
    /// <param name="effect"></param>
    public void updateNotify(Effect effect){
        Observer.onUpgradeNotify(effect);
    }

    /// <summary>
    /// Notifies the observer about wanting to destroying its tower
    /// </summary>
    public void destroyNotify() {
        Observer.onTowerDestroyNotify();
    }

    void Awake() {
        Observer = parent.GetComponent<TowerPlatformSystem>();
    }
}