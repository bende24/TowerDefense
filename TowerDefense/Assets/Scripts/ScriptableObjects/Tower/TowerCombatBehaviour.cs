using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCombatBehaviour {
    private TowerSystem tower;
    public void setTower(TowerSystem tower) { this.tower = tower; }

    /// <summary>
    /// This function is responsible for damaging the enemy as well as drawing the bullet whic is a line
    /// </summary>
    /// <param name="target"></param>
    /// <param name="bullet"> The bullet which is a line </param>
    /// <param name="firePoint"> The bullet's source point in the 3D world </param>
    public IEnumerator shoot(EnemySystem target, LineRenderer bullet, Transform firePoint) {
        target.recieveDamage(tower, tower.sharedData.stats[tower.runtimeData.level - 1].damage);

        bullet.SetPosition(1, target.transform.position - firePoint.position);

        bullet.enabled = true;
        yield return new WaitForSeconds(0.1f);
        bullet.enabled = false;
    }
}