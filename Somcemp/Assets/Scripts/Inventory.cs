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
    public static GameObject[] itemsImages = new GameObject[(int) Item_Type.Size];
    // Start is called before the first frame update
    void Start() {
        Transform[] transforms = GetComponentsInChildren<Transform>(true);

        SetItemsImages(transforms);
    }

    //Configura as imagens filhas do player pra saber qual corresponde a qual tipo de item
    private void SetItemsImages(Transform[] transforms) {

        if (transforms.Length != itemsImages.Length+2) {    // O +2 existe pq a funcao retorna o proprio elemento
                                                            // e existe o objeto para criar o icone do player no minimapa
            Debug.Log("ERRO! A quantidade de filhos do player é diferente da quantidade de tipos de itens existentes!");
            print("Filhos do player: " + transforms.Length + "Tipo de itens: " + itemsImages.Length);
            return;
        }
        for (int i = 1; i < transforms.Length-1; ++i) {   // Por isso o i comeca em 1
            itemsImages[i-1] = transforms[i].gameObject;    // E aqui é i-1
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private static void ChangePlayerItem(Item_Type item) {
        if (holdByPlayer > 0 && holdByPlayer < Item_Type.Size) { // Desativa o item antigo
            itemsImages[(int) holdByPlayer].SetActive(false);
        }
        if (item > 0 && item < Item_Type.Size) { // Ativa o item novo
            itemsImages[(int)item].SetActive(true);
        }
    }
}

[SerializeField]
public enum Item_Type{
    Nothing,
    Salgados,
    Bebidas,
    Pilhas,
    Size
}