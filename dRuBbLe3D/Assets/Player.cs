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

    private KeyCode leftKey = KeyCode.LeftArrow;
    private KeyCode rightKey = KeyCode.RightArrow;
    private KeyCode upKey = KeyCode.UpArrow;
    private KeyCode downKey = KeyCode.DownArrow;
    private KeyCode tiltLeftKey = KeyCode.A;
    private KeyCode tiltRightKey = KeyCode.D;
    private KeyCode extendKey = KeyCode.W;
    private KeyCode retractKey = KeyCode.S;

    private float leftRightForceMag = 100f;
    private float upDownForceMag = 60f;
    private float tiltMomentMag = 3f;
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
        // Use the player velocity to update the animation for running or jumping
        anim.SetFloat("velo", -bodyRb.velocity.x);
 
        KeyboardControls();
        PositionCamera();
    }

    // Control based on key presses for use on computers or tablets with keyboards
    void KeyboardControls() 
    {
        if (Input.GetKey(leftKey)) bodyRb.AddForce(leftRightForceMag, 0, 0);
        if (Input.GetKey(rightKey)) bodyRb.AddForce(-leftRightForceMag, 0, 0);
        if (Input.GetKey(upKey)) bodyRb.AddForce(0, upDownForceMag, 0);
        if (Input.GetKey(downKey)) bodyRb.AddForce(0, -upDownForceMag, 0);

        if (Input.GetKey(tiltLeftKey)) stoolRb.AddForce(tiltMomentMag, 0, 0);
        if (Input.GetKey(tiltRightKey)) stoolRb.AddForce(-tiltMomentMag, 0, 0);
        if (Input.GetKey(extendKey)) stoolRb.AddForce(0, extensionForceMag, 0);
        if (Input.GetKey(retractKey)) stoolRb.AddForce(0, -extensionForceMag, 0);

        if (Input.GetKey(KeyCode.Space)) {
            ball.GetComponent<Rigidbody>().position = transform.position + 4f * transform.up;
        }
    }

    void PositionCamera() {
        Vector3 diffPosition = transform.position - ball.transform.position;
        Vector3 averagePosition = 0.5f * (transform.position + ball.transform.position);
        Vector3 desiredPosition = averagePosition + (2.5f + diffPosition.magnitude) * Vector3.forward;
        desiredPosition.y = Mathf.Max(desiredPosition.y, 1.5f);
        mainCamera.transform.position += 0.01f * (desiredPosition - mainCamera.transform.position);
    }
}
