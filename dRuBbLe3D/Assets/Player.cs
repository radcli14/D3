using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject ball;
    public GameObject body;
    public GameObject stool;

    public Animator anim;

    private Rigidbody bodyRb;
    private Rigidbody stoolRb;

    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;
    private KeyCode tiltLeftKey = KeyCode.LeftArrow;
    private KeyCode tiltRightKey = KeyCode.RightArrow;
    private KeyCode extendKey = KeyCode.UpArrow;
    private KeyCode retractKey = KeyCode.DownArrow;

    private float leftRightForceMag = 100f;
    private float upDownForceMag = 100f;
    private float tiltMomentMag = 500f;
    private float extensionForceMag = 10f;

    // Start is called before the first frame update
    void Start()
    {
        bodyRb = body.GetComponent<Rigidbody>();
        stoolRb = stool.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardControls();
        
        // Use the player velocity to update the animation for running or jumping
        anim.SetFloat("velo", -bodyRb.velocity.x);
        //Debug.Log(anim.GetFloat("velo"));
    }

    void FixedUpdate()
    {
        PositionCamera();
    }

    // Control based on key presses for use on computers or tablets with keyboards
    void KeyboardControls() 
    {
        if (Input.GetKey(leftKey)) bodyRb.AddForce(leftRightForceMag, 0, 0);
        if (Input.GetKey(rightKey)) bodyRb.AddForce(-leftRightForceMag, 0, 0);
        if (Input.GetKey(upKey) && body.transform.position.y < 1f) bodyRb.AddForce(0, upDownForceMag, 0);
        if (Input.GetKey(downKey)) bodyRb.AddForce(0, -upDownForceMag, 0);

        if (Input.GetKey(tiltLeftKey)) stoolRb.AddTorque(0, 0, -tiltMomentMag);
        if (Input.GetKey(tiltRightKey)) stoolRb.AddTorque(0, 0, tiltMomentMag);
        if (Input.GetKey(extendKey)) stoolRb.AddForce(0, extensionForceMag, 0);
        if (Input.GetKey(retractKey)) stoolRb.AddForce(0, -extensionForceMag, 0);

        if (Input.GetKey(KeyCode.Space)) {
            ball.GetComponent<Rigidbody>().position = transform.position + 4f * transform.up;
        }
    }

    void PositionCamera() {
        Vector3 desiredPosition;
        if (ball.transform.position.y >= 1)
        {
            Vector3 diffPosition = transform.position - ball.transform.position;
            Vector3 averagePosition = 0.5f * (transform.position + ball.transform.position);
            desiredPosition = averagePosition + (2.5f + diffPosition.magnitude) * Vector3.forward;
        }
        else 
        {
            desiredPosition = transform.position + 2.5f * Vector3.forward;
        }
        desiredPosition.y = Mathf.Max(desiredPosition.y, 1f);
        mainCamera.transform.position += 0.1f * (desiredPosition - mainCamera.transform.position);
    }
}
