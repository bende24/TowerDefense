using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region Singleton
    public static GameManager Instance { get; set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }

        if(SceneManager.GetActiveScene().name == "Menu")
            Cursor.visible = true;
        else
            Cursor.visible = false;

    }
    #endregion
    
    public void loadNextLevel() {
        int nextMapIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextMapIndex);
    }

    public void gameOver() {

    }

    public void reloadMap() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}