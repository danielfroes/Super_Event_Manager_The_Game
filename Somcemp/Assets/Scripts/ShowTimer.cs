using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTimer : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = Timer.currentMinutes.ToString("0") + ":" + Timer.currentSeconds.ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
