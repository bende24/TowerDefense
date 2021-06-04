using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySystem: MonoBehaviour, ITowerTargetable {
    public Enemy enemy;
    public EnemyData enemyData;
    public Animator animator;
    public EnemyMovement enemyMovement;
    public SpriteRenderer enemySpriteRenderer;

    public bool isUnitTesting = false;

    void Awake() {
        enemy = new Enemy(enemyData);
        EntityManager.Instance.addEnemy(this);
    }

    /// <summary>
    /// This function is responsible for damaging the enemy
    /// </summary>
    public void damage() {
        if(EntityManager.Instance.Base == null) {
            Debug.LogWarning("No Base to damage!");
        } else {
            EntityManager.Instance.Base.baseData.getDamaged(enemy.damage);
            AudioManager.Instance.Play("Hit");
        }
        die();
    }

    /// <summary>
    /// This function is responsible for the enemy to destroy itself
    /// </summary>
    public void die() {
        EntityManager.Instance.removeEnemy(this);
        if(!isUnitTesting) {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// This function is responsible for damaging the enemy from a tower source
    /// </summary>
    /// <param name="source"></param>
    /// <param name="damage"></param>
    public void recieveDamage(TowerSystem source, int damage) {
        StartCoroutine("hitEffect");
        enemy.getDamaged(damage);
        if(enemy.isDead){
            giveReward(source);
            giveMoney();
            die();
        }
    }

    /// <summary>
    /// This function is responsible for 
    /// </summary>
    /// <param name="damage"></param>
    public void recieveDamageFromPlayer(int damage) {
        StartCoroutine("hitEffect");
        enemy.getDamaged(damage);
        if(enemy.isDead){
            giveMoney();
            giveMoney();
            die();
        }
    }

    /// <summary>
    /// This function is responsible for giving money to the player
    /// </summary>
    public void giveMoney() {
        EntityManager.Instance.Player.earnMoney(enemy.moneyDrop);
    }

    /// <summary>
    /// This function is responsible for giving xp reward to the killing tower
    /// </summary>
    /// <param name="tower"></param>
    public void giveReward(TowerSystem tower) {
        tower.gainExp(enemy.expDrop);
    }
    
    /// <summary>
    /// This function is responsible for slowing enemy
    /// </summary>
    /// <param name="slowPercentage"></param>
    public void getSlowed(float slowPercentage){
        enemyMovement.getSlowed(slowPercentage);
        enemySpriteRenderer.color = new Color(0.1f, 0.4f, 1f, 1f);
    }

    /// <summary>
    /// This function is responsible for reverting slow
    /// </summary>
    public void revertSlow(){
        enemyMovement.getSlowed(1.0f);
        if(enemySpriteRenderer != null)
            enemySpriteRenderer.color = Color.white;
    }

    /// <summary>
    /// This function is responsible for enemy hit effect
    /// </summary>
    IEnumerator hitEffect() {
        AudioManager.Instance.Play("Hit");
        Color prevColor = enemySpriteRenderer.color;
        enemySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        enemySpriteRenderer.color = prevColor;
    }
}