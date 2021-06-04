using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseSystem: MonoBehaviour{
    [SerializeField]
    public Base baseData;

    void Start() {
        EntityManager.Instance.Base = this;
    }
}