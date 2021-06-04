using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AOE", menuName = "Data/Effect/AOE")]
public class AOEEffect : Effect {
    public int damage;
    public float radius;

    public override IEnumerator apply(EnemySystem target, TowerSystem tower) {
        foreach (EnemySystem enemy in GetCloseEnemies(target))
        {
            enemy.recieveDamage(tower, damage);
        }
        target.recieveDamage(tower, damage);
        yield return new WaitForSeconds(0);
    }

    List<EnemySystem> GetCloseEnemies(EnemySystem target) {
        List<EnemySystem> enemies = EntityManager.Instance.enemies;
        List<EnemySystem> targets = new List<EnemySystem>();
        Vector3 currentPosition = target.transform.position;
        foreach (EnemySystem potentialTarget in enemies) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < radius) {
                targets.Add(potentialTarget);
            }
        }

        return targets;
    }
}