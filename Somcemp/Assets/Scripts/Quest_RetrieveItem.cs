using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_RetrieveItem : Quests {

    public Item_Type desiredItem;

    void OnEnable() {
        QuestItem.itemsReference[(int)desiredItem].questsRequirements++;
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
