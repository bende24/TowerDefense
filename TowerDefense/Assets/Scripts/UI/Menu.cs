using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject levelSelect;
    public GameObject menu;
    public void Exit() {
        Application.Quit();
    }

    public void Play() {
        SceneManager.LoadScene(1);
    }

    public void LevelSelect() {
        menu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void BackToMenu() {
        levelSelect.SetActive(false);
        menu.SetActive(true);
    }

    public void SelectLevel(int index) {
        SceneManager.LoadScene(index);
    }
}
