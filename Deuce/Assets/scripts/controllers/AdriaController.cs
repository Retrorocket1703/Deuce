using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdriaController : MonoBehaviour {

    public float moveSpeed;
    public float howClose;
    public float diagonalMoveSpeed;
    public Vector2 lastMove;
    public string startPoint;
    public Transform InLead;
    public GameObject dBox;

    private float currentMoveSpeed;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    public bool playerMoving; 
    private bool InLeadAdria;

    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        InLead = GameObject.Find("Adria").GetComponent<Transform>();
        InLeadAdria = true;
        GetComponent<BoxCollider2D>().enabled = true;
        DontDestroyOnLoad(transform.gameObject);
        dBox = GameObject.Find("Dialogue Box");
        
    }

    void Update()
    {

            if (Input.GetKeyUp("c"))
            {
                InLeadAdria = !InLeadAdria;
            }

            if (InLeadAdria == true)
            {
                InLead = GameObject.Find("Adria").GetComponent<Transform>();
                GetComponent<BoxCollider2D>().enabled = true;
            }

            if (InLeadAdria == false)
            {
                InLead = GameObject.Find("Zaakir2").GetComponent<Transform>();
                GetComponent<BoxCollider2D>().enabled = false;
            }

            if (InLeadAdria == true)
            {

                playerMoving = false;

                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                   myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y);
                   playerMoving = true;
                   lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                }

                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                    playerMoving = true;
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                }

                if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                {
                    myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
                }

                if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
                }

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
                {
                    currentMoveSpeed = moveSpeed * diagonalMoveSpeed;
                } else
                {
                    currentMoveSpeed = moveSpeed;
                }

            }

            if (InLeadAdria == false)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                playerMoving = false;
                if (Vector2.Distance(transform.position, InLead.position) > howClose)
                {
                    playerMoving = true;
                    transform.position = Vector2.MoveTowards(transform.position, InLead.position, moveSpeed * Time.deltaTime);
                    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                    {
                        lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                    }
                    if ((Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f))
                    {
                        lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                    }
                }
            }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);        
    }
}
