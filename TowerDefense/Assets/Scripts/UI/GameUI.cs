using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public Text money;
    public Text wave;
    public Text health;
    public GameObject healthBar;
    private float maxHealth = -9999;

    void Start() {
        if(EntityManager.Instance.Base != null)
            maxHealth = EntityManager.Instance.Base.baseData.health;
    }

    void Update() {
        if(maxHealth == -9999){
            maxHealth = EntityManager.Instance.Base.baseData.health;
        }
        money.text = (EntityManager.Instance.Player.money).ToString();
        wave.text = "Wave " + (RoundManager.Instance.wave + 1).ToString();
        int baseHealth = EntityManager.Instance.Base.baseData.health;
        health.text = maxHealth.ToString() + " / " + baseHealth.ToString();
        healthBar.GetComponent<RectTransform>().localPosition = new Vector2(baseHealth / maxHealth * 100 / 2 - 50 , healthBar.GetComponent<RectTransform>().localPosition.y);
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(baseHealth / maxHealth * 100, healthBar.GetComponent<RectTransform>().sizeDelta.y);
    }
}
