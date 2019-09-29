using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    private float currentSeconds = 0;
    // [SerializeField] private float startingSecond;
    private float currentMinutes = 0;
    [SerializeField] private TextMeshProUGUI secondsTextBox;
    [SerializeField] private TextMeshProUGUI minutesTextBox;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentSeconds >= 60)
        {
            currentMinutes += 1;
            currentSeconds = 0;
        }
        currentSeconds += 1 * Time.deltaTime;
      
        secondsTextBox.text = currentMinutes.ToString("0") + ":" +currentSeconds.ToString("00");
      
    }
}
