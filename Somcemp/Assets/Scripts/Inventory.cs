using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Item_Type holdByPlayer = Item_Type.Nothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[SerializeField]
public enum Item_Type{
    Nothing,
    Salgados,
    Bebidas
}