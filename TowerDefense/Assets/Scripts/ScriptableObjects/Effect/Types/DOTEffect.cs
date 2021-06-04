using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DOT", menuName = "Data/Effect/DOT")]
public class DOTEffect : Effect {
    public int tickDamage;
    public int tickNumber;

    public override IEnumerator apply(EnemySystem target, TowerSystem tower) {
        for (int i = 0; i < tickNumber; i++) {
            if (target) {
                target.recieveDamage(tower, tickDamage);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}