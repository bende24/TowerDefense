using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIButtons : MonoBehaviour
{

    public static GameUIButtons Instance;

    void Awake() {

        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    public GameObject musicOn;
    public GameObject musicOff;

    public GameObject SFXOn;
    public GameObject SFXOff;

    public void onReload() {
        musicOn.SetActive(AudioManager.Instance.isMusicOn);
        musicOff.SetActive(!AudioManager.Instance.isMusicOn);

        SFXOn.SetActive(AudioManager.Instance.isSFXOn);
        SFXOn.SetActive(!AudioManager.Instance.isSFXOn);
    }

    public void ToggleMusic() {
        AudioManager.Instance.ToggleMusic();
        musicOff.SetActive(!musicOff.activeInHierarchy);
        musicOn.SetActive(!musicOff.activeInHierarchy);
    }

    public void ToggleSFX() {
        AudioManager.Instance.ToggleSFX();
        SFXOff.SetActive(!SFXOff.activeInHierarchy);
        SFXOn.SetActive(!SFXOn.activeInHierarchy);
    }

}
