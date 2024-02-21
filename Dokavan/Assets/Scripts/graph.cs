using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class graph : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isBomb = false;
    spawnRate a;
    void Start()
    {
        transform.Translate(Vector3.right * Random.Range(-5,5));
        a = GameObject.FindGameObjectWithTag("Respawn").GetComponent<spawnRate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1 || transform.position.x < -5 || transform.position.x > 5)
        {
            Destroy(gameObject);
        }
        transform.position.Set(transform.position.x, transform.position.y, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            transform.localScale = Vector3.zero;
            Debug.Log(tag);
            if (gameObject.tag == "Fruits")
            {
                a.points++;
            }
            else {
                a.points -= 10;
            }
            
            

        }
    }
}
