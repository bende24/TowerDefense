using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slow", menuName = "Data/Effect/Slow")]
public class SlowEffect : Effect {
    [Range(0f, 1f)]
    public float slowPercentage;
    public float duration;

    public override IEnumerator apply(EnemySystem target, TowerSystem tower) {
        target.getSlowed(slowPercentage);
        yield return new WaitForSeconds(duration);
        target.revertSlow();
    }
}