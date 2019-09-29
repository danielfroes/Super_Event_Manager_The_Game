using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public static QuestItem[] itemsReference = new QuestItem[(int)Item_Type.Size];
    private int m_questRequirements;
    public int questsRequirements {
        get {
            return m_questRequirements;
        }
        set {
            m_questRequirements = value;
            itemActive = (value > 0);
        }
    }
    private bool itemActive = false;

    public Item_Type thisItem;

    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake() {
        if (itemsReference[(int)thisItem] != null)
            print("Acho que n ta muito certo encontrar duas referencias de item com o mesmo tipo");
        itemsReference[(int)thisItem] = this;
    }

    protected void OnTriggerEnter2D(Collider2D collision) {
        if (itemActive && collision.tag == "Player") {
            Interactor.interact += GetItem;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision) {
        if (itemActive && collision.tag == "Player") {
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