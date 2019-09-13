using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{

    public float moveSpeed;
    public float howClose;

    private Animator anim;
    //private Rigidbody2D myRigidbody;
    private bool playerMoving;
    private Vector2 lastMove;
    private Transform InLead;
    private bool InLeadAdria;
    private int lastMoveNotLead;
    private Vector2 direction;

    void Start()
    {
        anim = GetComponent<Animator>();
        //myRigidbody = GetComponent<Rigidbody2D>();
        InLead = GameObject.FindGameObjectWithTag("Adria").GetComponent<Transform>();
        InLeadAdria = true;
        GetComponent<BoxCollider2D>().enabled = false;
        playerMoving = false;
    }

    void Update()
    {
        
        SwitchLeader();
        Leader();
        NotLeader();

    }


    public void Leader() 
    {
        
        direction = Vector2.zero;

        if (InLeadAdria == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector2.up; 
            }


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction += Vector2.left;  
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector2.right;  
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                direction += Vector2.down;  
            }

            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);
            if( transform.position.x !=0 || transform.position.y != 0)
            {
                playerMoving = true;
            }

        }

        
    }

    public void NotLeader()
    {
        if (InLeadAdria == true)
        {

            GetComponent<BoxCollider2D>().enabled = false;
            playerMoving = false;
            if (Vector2.Distance(transform.position, InLead.position) > howClose)
            {
                playerMoving = true;
                transform.position = Vector3.MoveTowards(transform.position, InLead.position, moveSpeed * Time.deltaTime);
                if (direction.x != 0 || direction.y != 0)
                {
                    AnimateMovement(direction);
                }
            }

        }
    }

    public void SwitchLeader()
    {
        if (Input.GetKeyDown("a"))
        {
            InLeadAdria = true;
            InLead = GameObject.FindGameObjectWithTag("Adria").GetComponent<Transform>();
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if (Input.GetKeyDown("z"))
        {
            InLeadAdria = false;
            InLead = GameObject.FindGameObjectWithTag("Zaakir2").GetComponent<Transform>();
            GetComponent<BoxCollider2D>().enabled = true;

        }
    }

    public void AnimateMovement(Vector2 direction)
    {

        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetBool("AdriaInLead", InLeadAdria);
    }

}
