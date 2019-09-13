using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantDialogue : MonoBehaviour
{

    //hello
    public Text NameText;
    public Dialogue dialogue;
    public GameObject bBox;
    public GameObject dBox;
    private DialogueManager dman;
    public bool DS;

    private void Start()
    {
        dBox = GameObject.FindGameObjectWithTag("dBox");
        dman = GetComponent<DialogueManager>();
    }

    public void Update()
    {
        if (dBox.activeInHierarchy == false && bBox.activeInHierarchy == false)
        {
            dialogue.CurrentName = 0;
            DS = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
                dialogue.CurrentName += 1;
            }   
            
        }
    }
}
