using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2d(Collider2D col)
    {
        Debug.Log("teste");
    }
}
