using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest_GetItem : MonoBehaviour {

    public Item_Type desiredItem;
    private static Inventory playerInv = null;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (playerInv == null)
                playerInv = collision.GetComponent<Inventory>();
            if (desiredItem == playerInv.holdByPlayer)
                CompleteQuest();
        }
    }

    public void CompleteQuest() {

    }
}
