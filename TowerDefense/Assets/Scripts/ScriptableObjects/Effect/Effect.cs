using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Effect: ScriptableObject {
    public int cost;
    public Color bulletColor;

    /// <summary>
    /// This function applies its effect on the enemy
    /// </summary>
    /// <param name="target"> The target </param>
    /// <param name="tower"> The tower which is shooting </param>
    public abstract IEnumerator apply(EnemySystem target, TowerSystem tower);
}