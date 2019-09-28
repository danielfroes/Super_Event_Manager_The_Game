using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour {


    public delegate void Interact();
    public static Interact interact;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (interact != null && Input.GetButtonDown("Interact"))
            interact();
    }

}
