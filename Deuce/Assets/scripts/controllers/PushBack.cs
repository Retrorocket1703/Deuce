using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack1 : MonoBehaviour {

    public bool pushBack;
    public float xValue;
    public float yValue;
    public float moveSpeed;
    public Transform InLead;

	void Start () {
        pushBack = false;
        InLead = GameObject.Find("Adria").GetComponent<Transform>();
    }

    void Update() {

        if (pushBack == true)
        {
            InLead.position = Vector2.MoveTowards(InLead.position, InLead.position + new Vector3(xValue, yValue), moveSpeed * Time.deltaTime);
            pushBack = false;
        }

	}
}
