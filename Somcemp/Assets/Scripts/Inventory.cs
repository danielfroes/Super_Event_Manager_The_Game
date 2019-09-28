using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private static Item_Type m_holdByPlayer;
    public static Item_Type holdByPlayer {
        get {
            return m_holdByPlayer;
        }
        set {
            ChangePlayerItem(value);
            m_holdByPlayer = value;
        }
    }
    public static List<GameObject> itemsImages;
    // Start is called before the first frame update
    void Start() {
        //itemsImages = GetComponentsInChildren<>
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static void ChangePlayerItem(Item_Type item) {
        if (holdByPlayer > 0 && )
    }
}

[SerializeField]
public enum Item_Type{
    Nothing,
    Salgados,
    Bebidas
}