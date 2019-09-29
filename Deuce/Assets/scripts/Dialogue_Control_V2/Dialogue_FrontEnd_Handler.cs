using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_FrontEnd_Handler : MonoBehaviour
{
    bool StartDialogue = false;
    [Header("General")]
    public int PriorityKey;
    public string Path;
    public int Line;
    public char Delimiter;
    public bool KeyWordSearch;
    public string KeyWord;
    public Transform DatabaseManager;
    public Text Output;

    [Header("Trigger Type")]
    public string Trigger;

    [Header("Trigger Specific Values")]
    public GameObject TriggerBox;
    //InCutScene hasn't been implemented yet, as there is no identifier for cutscenes.
    public bool InCutScene = false;

    [Header("Other")]
    public string OutputInternal;
    public int EndRead = 1;

    void Start()
    {
        while (EndRead == 1)
        {
            if (Dialogue_Database.IsReading = false)
            {
                DatabaseManager.GetComponent<Dialogue_Database>().ReadFromTextDatabase(Path, Delimiter, Line, KeyWordSearch, KeyWord);
                OutputInternal = Dialogue_Database.VolatileString;
                Dialogue_Database.IsReading = false; 
                EndRead = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(StartDialogue == true)
        {
            
        }
    }

    public void OnTriggerEnter2D(Collider2D DialogueTrigger)
    {
        StartDialogue = true;
    }
}
