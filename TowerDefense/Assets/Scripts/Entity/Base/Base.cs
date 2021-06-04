using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Base : Entity {
    public int health;
    public bool isDead = false;
    public bool isUnitTesting = false;

    public void getDamaged(int damage) {
        health -= damage;
        if (health <= 0) {
            isDead = true;
            if(!isUnitTesting)
                PauseMenu.Instance.Defeat();
        }
    }
}