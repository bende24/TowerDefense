using System.Collections;
using UnityEngine;

[System.Serializable]
public class Player : Entity {
    public int money = 100;
    public GameObject arrow;
    public Transform bowPos;
    public int damage;
    public float shootDelay;
    [HideInInspector]
    public float lastShootTime;

    /// <summary>
    /// This function is responsible for paying the tower cost
    /// </summary>
    /// <param name="cost"></param>
    public void pay(int cost) {
        money -= cost;
        money = (money < 0) ? 0 : money;
        Debug.Log(money);
    }

    /// <summary>
    /// This function is responsible for earning money
    /// </summary>
    /// <param name="erning"></param>
    public void earnMoney(int earning) {
        money += earning;
    }
}