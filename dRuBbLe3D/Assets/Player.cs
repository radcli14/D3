using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject body;
    public GameObject stool;
    private Rigidbody bodyRb;
    private Rigidbody stoolRb;

    private float leftRightForceMag = 100f;
    private float upDownForceMag = 100f;

    // Start is called before the first frame update
    void Start()
    {
        bodyRb = body.GetComponent<Rigidbody>();
        stoolRb = stool.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftRightControl();
        UpDownControl();
    }

    void LeftRightControl() 
    {
        // Keyboard controls
        if (Input.GetKey(KeyCode.LeftArrow)) 
        { 
            bodyRb.AddForce(leftRightForceMag, 0, 0);
        } 
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            bodyRb.AddForce(-leftRightForceMag, 0, 0);
        }
    }

    void UpDownControl() 
    {
        // Keyboard controls
        if (Input.GetKey(KeyCode.UpArrow)) 
        { 
            bodyRb.AddForce(0, upDownForceMag, 0);
        } 
        if (Input.GetKey(KeyCode.DownArrow)) 
        {
            bodyRb.AddForce(0, -upDownForceMag, 0);
        }
    }
}
