using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public GameObject followTarget;
    public Vector3 targetPosition;
    public float moveSpeed;
    public bool InLeadAdria;
    public GameObject bBox;
    public GameObject dBox;

    void Start()
    {
        bBox = GameObject.Find("black outline");
        dBox = GameObject.Find("Dialogue Box");
        InLeadAdria = true;
        followTarget = GameObject.Find("Adria");  
    }

    private void Update()
    {
        if (dBox.activeInHierarchy == false)
        {
            if (Input.GetKeyDown("c"))
            {
                InLeadAdria = !InLeadAdria;
            }  
        }

        if (InLeadAdria == true)
        {
            followTarget = GameObject.Find("Adria");
        }
        else
        {
            followTarget = GameObject.Find("Zaakir2");
        }

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
