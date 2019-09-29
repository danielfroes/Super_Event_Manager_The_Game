using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quests : MonoBehaviour {

    public string[] questDescriptions;
    public string thisQuestDescription;

    protected virtual void OnEnable() {
        transform.GetChild(0).gameObject.SetActive(true);
        QuestManager.activeQuestsDescription.Add(thisQuestDescription);
    }
    protected virtual void OnDisable() {
        transform.GetChild(0).gameObject.SetActive(false);
        QuestManager.activeQuestsDescription.Remove(thisQuestDescription);
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
