using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    
    public static float currentSeconds = 0;
    // [SerializeField] public static float startingSecond;
    public static float currentMinutes = 0;
    [SerializeField] private TextMeshProUGUI secondsTextBox;
    [SerializeField] private TextMeshProUGUI minutesTextBox;
    public static bool stopTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        currentMinutes = 0;
        currentSeconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!stopTimer)
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
}
