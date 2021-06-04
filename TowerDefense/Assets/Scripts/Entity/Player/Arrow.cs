using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public int damage;

    /// <summary>
    /// This function is responsible for launching the arrow
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="velocity"></param>
    public void launch(int damage, Vector2 velocity) {
        this.damage = damage;
        GetComponent<Rigidbody2D>().velocity = velocity;
        float direction = Mathf.Sign(velocity.x);
        transform.localScale = new Vector2(direction, 1);
    }

    /// <summary>
    /// This function is responsible for colliding with the enemy
    /// </summary>
    void OnTriggerEnter2D(Collider2D collision) {
        EnemySystem enemy = collision.GetComponent<EnemySystem>();
        if(enemy != null) {
            enemy.recieveDamageFromPlayer(damage);
        }
        Destroy(gameObject);
    }
}
