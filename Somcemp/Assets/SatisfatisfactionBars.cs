using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SatisfatisfactionBars : MonoBehaviour
{

    [SerializeField] private Image gameNightBar;
    [SerializeField] private Image palestraBar;
    [SerializeField] private Image coffeBar;
    public float damageToBarPalestra;
    public float damageToBarGameNight;
    public float damageToBarCoffe;
    public float timeToDamage;
    private bool isDamaging;
    // Start is called before the first frame update
    void Start()
    {
        gameNightBar.fillAmount = 1;
        palestraBar.fillAmount = 1;
        coffeBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDamaging)
            StartCoroutine("DealDamageToBar");
    }

    IEnumerator DealDamageToBar()
    {
        isDamaging = true;
        gameNightBar.fillAmount -= damageToBarGameNight;
        coffeBar.fillAmount -= damageToBarCoffe;  
        palestraBar.fillAmount -= damageToBarPalestra;
        yield return new WaitForSeconds(timeToDamage);  
        isDamaging = false;
    }
}
