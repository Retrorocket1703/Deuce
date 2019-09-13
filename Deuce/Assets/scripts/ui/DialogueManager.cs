using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text dialogueText;
    public Text nameText;
    public Dialogue dialogue;
    public Names Names;
    public GameObject bBox;
    public GameObject dBox;
    public bool activated;
    public bool endDCalled;

    private Queue<string> sentences;
    private Queue<string> Snames;
    private DialogueTrigger DT;
    private OnEnterDialogue OED;

    //hello
    void Start()
    {
        dBox = GameObject.FindGameObjectWithTag("dBox");
        sentences = new Queue<string>();
        activated = false;        
        DT = GetComponent<DialogueTrigger>();
        OED = GetComponent<OnEnterDialogue>();
    }

    void Update()
    {
        if (endDCalled == true)
        {
            endDCalled = false;
        }

        if (activated == false)
        {
            dBox.SetActive(false);
            bBox.SetActive(false);
        }
        else
        {
            dBox.SetActive(true);
            bBox.SetActive(true);
        }        
    }

    public void StartDialogue(Dialogue dialogue)
    {        
        activated = true;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        sentences.Clear();
        activated = false;
        endDCalled = true;  
    }

}