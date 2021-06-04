using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;
    public bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject victoryUI;
    public GameObject defeatUI;
    public GameObject lastLevelUI;
    private int currentSceneNum;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        } else {
            Instance = this;
        }
        Time.timeScale = 1f;
        isGamePaused = false;
        currentSceneNum = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(isGamePaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        isGamePaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        EndGamePause();
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        isGamePaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void RestartScene() {
        Time.timeScale = 1f;
        isGamePaused = false;
        GameManager.Instance.reloadMap();
    }

    public void NextLevel() {
        GameManager.Instance.loadNextLevel();
    }
    
    public void Victory() {
        if(SceneManager.sceneCountInBuildSettings > currentSceneNum){
            victoryUI.SetActive(true);
            EndGamePause();
        } else{
            lastLevelUI.SetActive(true);
            EndGamePause();
        }
    }

    public void Defeat() {
        defeatUI.SetActive(true);
        EndGamePause();
    }

    private void EndGamePause(){
        Time.timeScale = 0f;
        Cursor.visible = true;
        isGamePaused = true;
    }
}
