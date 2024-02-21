using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    Quaternion rot;
    public float speed;
    public float gunSpeed = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,Input.GetAxis("Mouse Y"));
        rot = transform.rotation;
        if (Input.GetMouseButtonDown(0)) {
            shoot();
        }
    }
    void shoot() {
        GameObject pew = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        pew.transform.localScale = Vector3.one * 0.1f;
        pew.transform.rotation = rot;
        Rigidbody move = pew.AddComponent<Rigidbody>();
        move.detectCollisions = false;
        move.useGravity = false;
        move.AddRelativeForce(Vector3.up*gunSpeed);
    }
}
