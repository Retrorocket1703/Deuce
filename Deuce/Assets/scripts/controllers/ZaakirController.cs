using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaakirController : MonoBehaviour {

    //les variables d'environnement
    

    public float moveSpeed;
    public float howClose; 
    public float diagonalMoveSpeed;
    public Vector2 lastMove;
    public Transform InLead;
    public string startPoint;
    public GameObject dBox;

    private float currentMoveSpeed;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private bool playerMoving;        
    private bool InLeadAdria;
    
    
     
    void Start() {
        // les choses que je dois initialiser
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        InLead = GameObject.Find("Adria").GetComponent<Transform>();
        InLeadAdria = true;
        GetComponent<BoxCollider2D>().enabled = false;
        DontDestroyOnLoad(transform.gameObject);
        dBox = GameObject.Find("Dialogue Box");
    }

    void Update()
    {

            // si la touche "c" est appuyée, la personne qui dirige change
            if (Input.GetKeyUp("c"))
            {
                InLeadAdria = !InLeadAdria;
            }

            if (InLeadAdria == true)
            {
                InLead = GameObject.Find("Adria").GetComponent<Transform>();
                GetComponent<BoxCollider2D>().enabled = false;
            }

            if (InLeadAdria == false)
            {
                InLead = GameObject.Find("Zaakir2").GetComponent<Transform>();
                GetComponent<BoxCollider2D>().enabled = true;
            }





            if (InLeadAdria == false) // si la personne qui dirige c'est Zaakir
            {

                playerMoving = false;

                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) //movement horizontal
                {

                    //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                    myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, myRigidbody.velocity.y); // déplacement du personnage
                    playerMoving = true; // déplacement du personnage
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); // direction que le personnage fait face
                }

                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) // movement vertical
                {
                    //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed); // déplacement du personnage
                    playerMoving = true; // déplacement du personnage
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical")); // direction que le personnage fait face
                }

                if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
                {
                    myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y); // forme rigide du personnage pour horizontal
                }
            
                if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f); // forme rigide du personnage pour vertical
                }

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
                {
                    currentMoveSpeed = moveSpeed * diagonalMoveSpeed;
                }
                else
                {
                    currentMoveSpeed = moveSpeed;
                }

            }

            if (InLeadAdria == true) // si le personnage en charge c'est Adria
            {
                GetComponent<BoxCollider2D>().enabled = false; // le personnage ne fera pas de collisions
                playerMoving = false; // le personnage ne se déplace pas
                if (Vector2.Distance(transform.position, InLead.position) > howClose) // si le personnage est plus de 3 unités de distance de loin
                {
                    playerMoving = true; // déclare que le personnage se déplace
                    transform.position = Vector2.MoveTowards(transform.position, InLead.position, moveSpeed * Time.deltaTime); // le personnage se déplace vers la personne qui dirige
                    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                    {
                        lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); // direction auquel le personnage fait face
                        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                        {
                            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                        }
                    }
                    if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                    {
                        lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical")); // direction auquel le personnage fait face
                        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                        {
                            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                        }
                    }
                }

            }

            // animations
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        
    }

}

