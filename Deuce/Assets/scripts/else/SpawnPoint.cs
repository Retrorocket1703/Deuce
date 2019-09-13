using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    private ZaakirController Zaakir;
    private AdriaController Adria;
    private CameraController theCamera;

    public Vector2 startDirection;
    public string sPoint;

	// Use this for initialization
	void Start () {

        Adria = FindObjectOfType<AdriaController>();
        Zaakir = FindObjectOfType<ZaakirController>();

        if(Adria.startPoint == sPoint || Zaakir.startPoint == sPoint) { 

        Adria.lastMove = startDirection;
        Zaakir.lastMove = startDirection;

        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        Adria.transform.position = transform.position;
        Zaakir.transform.position = transform.position;
        }
    }
	
}
