using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_RetrieveItem : Quests {

    public Item_Type desiredItem;    

    private void Awake() {
        questDescriptions = new string[] {
            "A sala de coffee está precisando de mais coxinhas.",
            "A sala de coffee está precisando de mais bebidas!"
        };
        thisQuestDescription = questDescriptions[(int)desiredItem - 1];
    }

    protected override void OnEnable() {
        //print("Buscando item " + desiredItem);
        transform.GetChild(0).gameObject.SetActive(true);
        QuestItem.itemsReference[(int)desiredItem].questsRequirements++;
        QuestManager.activeQuestsDescription.Add(thisQuestDescription);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public override void QuestInteract() {
        print("Interagindo com a quest");
        if (desiredItem == Inventory.holdByPlayer)
            CompleteQuest();
    }

    public override void CompleteQuest() {
        print("Quest Completa!");
        Inventory.holdByPlayer = Item_Type.Nothing;
        QuestItem.itemsReference[(int)desiredItem].questsRequirements--;

        QuestManager.questsAvailable.Add(this);
        this.enabled = false;
    }
}
