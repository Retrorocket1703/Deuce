using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JerryController : MonoBehaviour {

    public GameObject riverS;
    public float moveSpeed;
    public GameObject Duo;
    public GameObject referenceP;
    public Text NameText;
    public Dialogue dialogue;
    public GameObject dBox;
    public bool DS;
    public Transform Jerry;
    public Transform Riverside; 
    public float timeLeft;
    public bool Walking;
    public bool Ready;

    private DialogueManager dman;
    private Animator anim;
    
    void Start () {
        anim = GetComponent<Animator>();
        Walking = false;
        referenceP = GameObject.Find("referencePoint");
        Duo = GameObject.Find("strandedDuo");
        riverS = GameObject.Find("riverside");
        dialogue.CurrentName = 0;
        dBox = GameObject.FindGameObjectWithTag("dBox");
        dman = GetComponent<DialogueManager>();
        anim.SetBool("IsWwalking", Walking);
        Riverside = GameObject.Find("Riverside").GetComponent<Transform>();
        Jerry = GameObject.FindGameObjectWithTag("NPC").GetComponent<Transform>();
    }
	
	void Update ()
    {
        if (Duo.transform.position == referenceP.transform.position)
        {
            transform.position = Vector2.MoveTowards(transform.position, riverS.transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == riverS.transform.position && timeLeft > 0)
            {               
                timeLeft -= Time.deltaTime;                               

                if (timeLeft < 0)
                {
                    Ready = true;

                    if (Ready == true)
                    {
                        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

                        if (Input.GetKeyDown(KeyCode.X))
                        {
                            dialogue.CurrentName += 1;
                            dman.DisplayNextSentence();
                        }
                    }                    
                }
            }
        }        
	}
}
