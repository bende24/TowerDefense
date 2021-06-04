using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject{

    public EnemyType type;
    public int health;
    public int damage;
    public float movementSpeed;
    public float spawntime;
    public int xpValue;
    public int moneyValue;
}
