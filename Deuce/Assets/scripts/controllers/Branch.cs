using UnityEngine;
using System.Collections;

public class Branch : MonoBehaviour
{
    public bool gameStart;
    public Transform RP;
    public float speed;
    public bool CamOnDuo;

    void Start()
    {
        gameStart = true;
        RP = GameObject.Find("referencePoint").GetComponent<Transform>();
        CamOnDuo = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (gameStart == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, RP.position, speed * Time.deltaTime);
        }

        if (transform.position != RP.position)
        {
            CamOnDuo = true;
        }
        if (transform.position == RP.position)
        {
            CamOnDuo = false;
        }
        
    }
}