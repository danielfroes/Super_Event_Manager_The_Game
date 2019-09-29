using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{



    private Rigidbody2D rb2d;
    private Animator legAnim;
    [SerializeField] private float speed;
    private bool isMoving = false;
    [SerializeField] float timeToMove ,minTimeToWait, maxTimeToWait;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        legAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            StartCoroutine("RandomMovement");
        }
    }

    IEnumerator RandomMovement()
    {
        
        isMoving = true;
        
        yield return new WaitForSeconds(Random.Range(minTimeToWait,maxTimeToWait));

        legAnim.SetBool("isMoving",true);
        int xRand = Random.Range(-1,2);
        int yRand = Random.Range(-1,2);
        
        rb2d.velocity = new Vector3( xRand * speed * Time.deltaTime * 64, yRand * speed * Time.deltaTime * 64, 0) ;           
        transform.eulerAngles = new Vector3 (0,0,Vector3.SignedAngle(Vector3.up, rb2d.velocity, Vector3.forward)); 

        yield return new WaitForSeconds(timeToMove); // tempo que anda

        rb2d.velocity = Vector3.zero;
        legAnim.SetBool("isMoving", false);
        
        
        isMoving = false;
        
    }
}
