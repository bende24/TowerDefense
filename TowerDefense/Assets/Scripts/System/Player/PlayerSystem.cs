using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystem: MonoBehaviour{
    public Player player;

    void Update() {
        if(Input.GetButtonDown("Fire1") && !PauseMenu.Instance.isGamePaused && player.lastShootTime <= 0) {
            shoot();
            player.lastShootTime = player.shootDelay;
        }
        player.lastShootTime -= Time.deltaTime;
    }

    void Start() {
        EntityManager.Instance.Player = player;
    }

    /// <summary>
    /// This function is responsible for shooting
    /// </summary>
    void shoot() {
        GameObject newArrow = Instantiate(player.arrow, player.bowPos.position, Quaternion.identity);
        newArrow.GetComponent<Arrow>().launch(player.damage, new Vector2(transform.localScale.x * 6, 0));
    }
}