using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    Camera cam;
    public float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")) * speed;
        Vector3 rotation = new Vector3(0, Input.GetAxis("Mouse X"), 0) * sensitivity;
        transform.Translate(movement);
        transform.Rotate(rotation);
    }
    private void OnGUI()
    {
        cam.transform.Translate(new Vector3(0,Input.mouseScrollDelta.y * sensitivity,Input.mouseScrollDelta.y * 2 * sensitivity));
    }

}
