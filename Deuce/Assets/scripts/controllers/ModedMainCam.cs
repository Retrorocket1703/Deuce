using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

public class ModedMainCam : MonoBehaviour
{
    public float FinalUnitSize { get { return finalUnitSize; } }
    public int PixelsPerUnit { get { return pixelsPerUnit; } }
    public int VertUnitsOnScreen { get { return verticalUnitsOnScreen; } }

    [SerializeField]
    private int pixelsPerUnit = 16;
    [SerializeField]
    private int verticalUnitsOnScreen = 4;
    private float finalUnitSize;
    private new Camera camera;
    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;
    private bool InLeadAdria;
    public Camera ordinaryCamera;
    public GameObject bBox;
    public GameObject dBox;
    public Branch duoCam;
    public GameObject Duo;
    public GameObject Jerry;

    void Start()
    {
        duoCam = GetComponent<Branch>();      
        Duo = GameObject.Find("strandedDuo");
        followTarget = Duo;
    }

    void Awake()
    {
        camera = gameObject.GetComponent<Camera>();
        Assert.IsNotNull(camera);

        SetOrthographicSize();
    }

    void SetOrthographicSize()
    {
        var tempUnitSize = Screen.height / verticalUnitsOnScreen;
        finalUnitSize = GetNearestMultiple(tempUnitSize, pixelsPerUnit);
        camera.orthographicSize = Screen.height / (finalUnitSize * 2.0f);
    }

    int GetNearestMultiple(int value, int multiple)
    {
        int rem = value % multiple;
        int result = value - rem;
        if (rem > (multiple / 2))
            result += multiple;

        return result;
    }

    private void Update()
    {
        followTarget = Duo;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}