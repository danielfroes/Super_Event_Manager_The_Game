using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    // public bool canMove = false;
    
    private Animator legAnim;


    void Start()
    {
        legAnim = GetComponentInChildren<Animator>();
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
            Debug.Log(legAnim.name);
            legAnim.SetBool("isMoving", true);
        }
        else
        {
            legAnim.SetBool("isMoving", false);
        }


        if(Mathf.Abs(xInput) > 0 && Mathf.Abs(yInput) > 0) //move diagonally 
        {
            transform.Translate(Vector3.up * yInput *  (speed/Mathf.Sqrt(2)) * Time.deltaTime, Space.World);
            transform.Translate(Vector3.right * xInput *  speed/Mathf.Sqrt(2) * Time.deltaTime, Space.World);

            if(yInput > 0)
                transform.eulerAngles = new Vector3(0, 0,  -45 * xInput);
            else
                 transform.eulerAngles = new Vector3(0, 0,  -135 * xInput);    

        }
        else if(Mathf.Abs(xInput) > 0) //move horizontally
        {   
            transform.Translate(Vector3.right * xInput * speed * Time.deltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 0, - 90 * xInput);
        }
        else if(Mathf.Abs(yInput) > 0) //move vertically
        {   
            transform.Translate(Vector3.up * yInput * speed * Time.deltaTime, Space.World);
            
            if(yInput > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 180);                
        }
       

    }
}