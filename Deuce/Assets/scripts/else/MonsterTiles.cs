using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTiles : MonoBehaviour
{
    // when the character enters the zone, there is a probability a monster will spawn
    // when the character moves "1" unit, the map updates the spawn encounter probability

    public Transform Adria;
    public Transform Zaakir;
    private bool zLead;
    public AdriaController leader;
    private int probability = Random.Range(0, 100);
    private bool hasEntered;
    private bool hasMoved;
    private bool justWon;
    public int encounterChance;
    public string LevelToLoad;
    public string SourceLevel;

    void Start()
    {
        Adria = GameObject.Find("Adria").GetComponent<Transform>();
        Zaakir = GameObject.Find("Zaakir").GetComponent<Transform>();
        leader = GameObject.Find("Adria").GetComponent<AdriaController>();
    }

    void Update()
    {
        if(leader.InLead == Adria)
        {
            if (hasEntered == true)
            {
                if(Adria.position.x%2 == 0 || Adria.position.y%2 == 0)
                {
                    if(justWon == false)
                    {
                        if(probability <= encounterChance)
                        {
                            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);
                        }
                    }
                }
                else
                {
                    justWon = false;
                }
            }
        }
        else
        {
            if(hasEntered == true)
            {
                if (Zaakir.position.x % 2 == 0 || Zaakir.position.y % 2 == 0)
                {
                    if (justWon == false)
                    {
                        if (probability <= encounterChance)
                        {
                            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);
                        }
                    }
                }
                else
                {
                    justWon = false;
                }
            }
        }

        

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hasEntered = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hasEntered = false;
        }
    }
}
