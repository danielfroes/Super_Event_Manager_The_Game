using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quests : MonoBehaviour {

    protected virtual void OnEnable() {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    protected virtual void OnDisable() {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Interactor.interact += QuestInteract;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Interactor.interact -= QuestInteract;
        }
    }

    public abstract void QuestInteract();

    public abstract void CompleteQuest();
}
