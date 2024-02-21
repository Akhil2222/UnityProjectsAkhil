using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pewpew : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 half = new Vector3(Screen.width / 2, Screen.height / 2, 0);

    void Start()
    {
        Debug.Log(half);
    }
    float sigmoid(float a)
    {
        return 1f / (1+Mathf.Pow(10,-a/100)) - 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }

    void shootBullet() {
        GameObject a = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        a.GetComponent<SphereCollider>().radius = 0.01f;
        a.AddComponent<Rigidbody>();
        a.transform.localScale = new Vector3(0.10f,0.1f,0.1f);
        a.GetComponent<Rigidbody>().useGravity = false;
        a.GetComponent<Rigidbody>().AddForce(transform.rotation.eulerAngles*100);
    }
}
