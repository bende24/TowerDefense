using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Entity {
    public Player builder;
    public bool isEnabled = true;
    public int exp = 0;
    public int level = 1;
    public float attackTimer;
    public Effect effect;

    public Tower(float attackSpeed) {
        attackTimer = attackSpeed;
        builder = EntityManager.Instance.Player;
    }
}