using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile: MonoBehaviour{
    protected int damage;
    protected float speed;

    public Projectile(int damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }
}