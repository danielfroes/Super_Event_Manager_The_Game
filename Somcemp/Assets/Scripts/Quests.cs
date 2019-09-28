using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quests : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
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
