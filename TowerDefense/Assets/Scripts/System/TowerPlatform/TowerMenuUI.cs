using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TowerMenuUI {
    public GameObject buildingUI;
    public GameObject towerUI;
    public GameObject displayUI;
    public GameObject currentUI;
    private GameObject effectUI;
    public Text levelDisplay;
    public Text effectDisplay;

    public void changeLevelDisplay(int level){
        levelDisplay.text = level.ToString();
    }
    public void changeEffectDisplay(Effect effect){
        effectDisplay.text = effect?.name;
    }

    private void resetDisplay(){
        changeLevelDisplay(1);
        changeEffectDisplay(null);
    }

    public void changeToBuild() {
        UIVisibility(effectUI, false);
        changeUIMenuTo(buildingUI);
    }

    public void changeToMenu(TowerType towerType) {
        resetDisplay();
        changeUIMenuTo(towerUI);
        int i = 0;
        switch (towerType) {
            case TowerType.NORMAL:
                i = 0;
                break;
            case TowerType.SLOW:
                i = 1;
                break;
            case TowerType.FAST:
                i = 2;
                break;
        }
        effectUI = towerUI.transform.GetChild(i).gameObject;
        UIVisibility(effectUI, true);
    }

    public void interaction(Interaction signal) {
        switch (signal) {
            case Interaction.INTERACT:
                UIVisibility(true);
                return;
            case Interaction.UNINTERACT:
                UIVisibility(false);
                return;
        }
    }

    private void changeUIMenuTo(GameObject ui) {
        UIVisibility(false);
        currentUI = ui;
        UIVisibility(true);
    }

    private void UIVisibility(bool visibility) {
        currentUI.SetActive(visibility);
        Cursor.visible = visibility;
    }
    private void UIVisibility(GameObject ui, bool visibility) {
        if(ui != null){
            ui.SetActive(visibility);
            Cursor.visible = visibility;
        }
    }
}