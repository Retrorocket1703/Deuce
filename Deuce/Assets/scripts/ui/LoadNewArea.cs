using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {

    public string LevelToLoad;
    public string exitpoint;

    private ZaakirController Zaakir;
    private AdriaController Adria;

	// Use this for initialization
	void Start () {
        Adria = FindObjectOfType<AdriaController>();
        Zaakir = FindObjectOfType<ZaakirController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") { 
            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelToLoad);
            Adria.startPoint = exitpoint;
            Zaakir.startPoint = exitpoint;
        }
    }
}
