using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    // public bool canMove = false;
    
    private Animator legAnim;
    private Rigidbody2D rb2d;

    void Start()
    {
        legAnim = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        float xInput = Input.GetAxisRaw("Horizontal"); 
        float yInput = Input.GetAxisRaw("Vertical");


        //Check if the player movement input was pressed
        if(Mathf.Abs(xInput) > 0 || Mathf.Abs(yInput) > 0)
        {
            //Debug.Log(legAnim.name);
            legAnim.SetBool("isMoving", true);
        }
        else
        {
            legAnim.SetBool("isMoving", false);
        }


        if(Mathf.Abs(xInput) > 0 && Mathf.Abs(yInput) > 0) //move diagonally 
        {
            rb2d.velocity = Vector3.up * yInput *  (speed/Mathf.Sqrt(2))  + 
                            Vector3.right * xInput *  speed/Mathf.Sqrt(2) * Time.deltaTime * 64 ;

            transform.eulerAngles = new Vector3 (0, 0, Vector3.SignedAngle(Vector3.up, rb2d.velocity, Vector3.forward));

        }
        else if(Mathf.Abs(xInput) > 0) //move horizontally
        {   
            rb2d.velocity = Vector3.right * xInput * speed * Time.deltaTime * 64;
            //Debug.Log(rb2d.velocity); 
            transform.eulerAngles = new Vector3 (0, 0, Vector3.SignedAngle(Vector3.up, rb2d.velocity, Vector3.forward));
        }
        else if(Mathf.Abs(yInput) > 0) //move vertically
        {   
            rb2d.velocity = Vector3.up * yInput * speed * Time.deltaTime * 64 ;
            
            transform.eulerAngles = new Vector3 (0,0,Vector3.SignedAngle(Vector3.up, rb2d.velocity, Vector3.forward));            
        }
        else
        {
            rb2d.velocity = Vector3.zero;
        }
       

    }
}