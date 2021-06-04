using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerSystem : MonoBehaviour {
    public Tower runtimeData;
    public TowerData sharedData;
    private TowerCombatBehaviour combatBehaviour;
    public LineRenderer lineRenderer;
    public GameObject firePoint;
    public TowerPlatformSystem platformSystem;

    public void levelUp() {
        if (runtimeData.level < sharedData.expRequirements.Count) {
            runtimeData.level++;
            platformSystem.UI.changeLevelDisplay(runtimeData.level);
        }
    }

    public void gainExp(int exp) {
        runtimeData.exp += exp;
        if (runtimeData.exp >= sharedData.expRequirements[runtimeData.level - 1]) {
            levelUp();
        }
    }

    /// <summary>
    /// This function is responsible for waiting n seconds in between shooting
    /// </summary>
    /// <param name="target"></param>
    private void reload(EnemySystem target) {
        if (runtimeData.isEnabled) {
            runtimeData.attackTimer -= Time.deltaTime;
            if (runtimeData.attackTimer <= 0) {
                shoot(target);
                runtimeData.attackTimer = sharedData.stats[runtimeData.level - 1].attackSpeed;
            }
        }
    }

    /// <summary>
    /// This function is responsible for shooting and applying effect if it has
    /// </summary>
    /// <param name="target"></param>
    public void shoot(EnemySystem target) {
        if (target) {
            if (runtimeData.effect != null) {
                StartCoroutine(runtimeData.effect.apply(target, this));
            }
            StartCoroutine(combatBehaviour.shoot(target, lineRenderer, firePoint.transform));
        }
    }

    /// <summary>
    /// Finds the closest enemy
    /// </summary>
    /// <returns>The closest enemy</returns>
    EnemySystem GetClosestEnemy() {
        List<EnemySystem> enemies = EntityManager.Instance.enemies;
        EnemySystem bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (EnemySystem potentialTarget in enemies) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr && dSqrToTarget < sharedData.stats[runtimeData.level - 1].radius) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    public void refundMoney() {
        runtimeData.builder.earnMoney(sharedData.cost);
    }
    public void upgrade(Effect effect) {
        runtimeData.effect = effect;
        setBulletColor();
    }

    public void disable() {
        runtimeData.isEnabled = false;
    }

    public void enable() {
        runtimeData.isEnabled = true;
    }

    void Awake() {
        runtimeData = new Tower(sharedData.stats[0].attackSpeed);
        combatBehaviour = new TowerCombatBehaviour();
        combatBehaviour.setTower(this);
        setBulletColor();
    }

    private void setBulletColor() {
        if (runtimeData.effect != null) {
            lineRenderer.startColor = runtimeData.effect.bulletColor;
            lineRenderer.endColor = runtimeData.effect.bulletColor;
        } else {
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
        }
    }

    void Update() {
        if (!PauseMenu.Instance.isGamePaused) {
            EnemySystem target = GetClosestEnemy();
            reload(target);
        }
    }

    void onDestroy() {
        refundMoney();
    }
}