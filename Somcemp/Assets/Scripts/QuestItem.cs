using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public Item_Type thisItem;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Interactor.interact += GetItem;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            Interactor.interact -= GetItem;
        }
    }

    public void GetItem() {
        if(Inventory.holdByPlayer == Item_Type.Nothing) {
            print("Pegando item " + thisItem);
            Inventory.holdByPlayer = thisItem;
        }
    }
}
