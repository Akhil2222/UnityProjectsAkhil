using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    Vector3 shift;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shift = Vector3.up;
            transform.Rotate(Vector3.right * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            shift = Vector3.down;
            transform.Rotate(Vector3.right * -rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            shift = Vector3.left;
            transform.Rotate(Vector3.up * rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            shift = Vector3.right;
            transform.Rotate(Vector3.right * -rotationSpeed);
        }
        shift = Vector3.forward;
        transform.Translate(shift * speed);

        // tilt the plane up/down based on up/down arrow keys
    }
}
