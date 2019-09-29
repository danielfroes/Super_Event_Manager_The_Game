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
    private bool m_itemActive = false;
    private bool itemActive {
        get {
            return m_itemActive;
        }
        set {
            m_itemActive = value;
            iconeMinimapa.SetActive(value);
        }
    }
    private GameObject iconeMinimapa;
    public Item_Type thisItem;

    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake() {
        if (itemsReference[(int)thisItem] != null)
            print("Acho que n ta muito certo encontrar duas referencias de item com o mesmo tipo");
        itemsReference[(int)thisItem] = this;
        //print("Criada referencia para o item " + thisItem);
        iconeMinimapa = transform.GetChild(0).gameObject;
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