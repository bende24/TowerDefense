using System.Collections;
using UnityEngine;

public class TowerPlatformTrigger : Interactable, ITowerPlatformSubject {
    public GameObject buildingUI;
    public GameObject parent;

    public ITowerPlatformObserver Observer { get; set; }

    protected override void interact() {
        base.interact();
    }

    protected override void uninteract() {
        base.uninteract();
    }

    public void notify(Interaction signal) {
        Observer.onInteractNotify(signal);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            inRange();
        }
    }

    void Update() {
        if (isFocus) {
            if (Input.GetKeyDown(KeyCode.E) && !hasInteracted) {
                notify(Interaction.INTERACT);
                interact();
            } else if (Input.GetKeyDown(KeyCode.E) && hasInteracted) {
                notify(Interaction.UNINTERACT);
                uninteract();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            notify(Interaction.UNINTERACT);
            outOfRange();
        }
    }

    void Awake() {
        Observer = parent.GetComponent<TowerPlatformSystem>();
    }
}