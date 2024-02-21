using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COllided");
        GameObject.FindGameObjectWithTag("Respawn").GetComponent<spawnRate>().isDead = false;
        Camera.main.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
