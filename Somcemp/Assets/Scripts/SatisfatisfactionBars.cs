using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SatisfatisfactionBars : MonoBehaviour
{

    [SerializeField] private Image gameNightBar;
    public float damageToBar;
    public float timeToDamage;
    private bool isDamaging;
    // Start is called before the first frame update
    void Start()
    {
        gameNightBar.fillAmount = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDamaging)
            StartCoroutine("DealDamageToBar");


        if(gameNightBar.fillAmount <= 0 )
        {
            GameOver();
        }
    }

    IEnumerator DealDamageToBar()
    {
        isDamaging = true;
        gameNightBar.fillAmount -= damageToBar;
        
        yield return new WaitForSeconds(timeToDamage);  
        isDamaging = false;
    }

    public void HealBar(float amount) {
        gameNightBar.fillAmount += amount;
    }

    void GameOver()
    {
        Timer.stopTimer = true;
        SceneManager.LoadScene("GameOver");
    }
}
    