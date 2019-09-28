using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_RetrieveItem : Quests {

    public Item_Type desiredItem;

    // Start is called before the first frame update
    void Start() {
        
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
    }
}
