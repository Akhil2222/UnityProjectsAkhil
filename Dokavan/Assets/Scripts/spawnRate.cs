using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnRate : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject[] fruits;
    private GameObject[] bombs;
    public int spawnByFrames = 60;
    public float bombRate = 0.25f;
    private GameObject cursor;
    public Queue<GameObject> spawnQueue = new Queue<GameObject>();
    public int points = 0;
    public int maxScore = 0;
    public GameObject scoreboard;
    public bool isDead = false;
    void Start()
    {
        fruits = GameObject.FindGameObjectsWithTag("Fruits");
        bombs = GameObject.FindGameObjectsWithTag("Bombs");
        cursor = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(cursor);
    }

    // Update is called once per frame
    void Update()
    {
        spawnItem();
        moveCursor();
        GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshPro>().text = "Score:" + points.ToString() + "\n" + "High:" + maxScore.ToString();
        maxScore = Mathf.Max(maxScore, points);
        if(points < 0)
        {
            Camera.main.transform.rotation = Quaternion.Euler(0,180,0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
            points = 0;

        }
    }

    void moveCursor()
    {
        //(0,5)
        float x = 20*(Input.mousePosition.x-Screen.width / 2f) /Screen.width;
        float y = 20*(Input.mousePosition.y - Screen.height / 2f) / Screen.width + 5;
        //GameObject a = Instantiate(cursor);
        cursor.transform.position = new Vector3(x, y, 0);
    }

    public void spawnItem()
    {
        if(Time.frameCount % spawnByFrames == 0)
        {
            GameObject a;
            bool isBomb = Random.value < 0.25;
            if (isBomb)
            {
                a = Instantiate(bombs[Random.Range(0, bombs.Length)]);
            }
            else {
                a = Instantiate(fruits[Random.Range(0, fruits.Length)]);
            }
            a.transform.position = Vector3.zero;
            a.AddComponent<graph>();
            a.GetComponent<graph>().isBomb = isBomb;
            a.AddComponent<Rigidbody>();
            a.AddComponent<BoxCollider>();
            a.GetComponent<Rigidbody>().AddForceAtPosition(
                new Vector3(Mathf.Cos(Random.value * Mathf.PI / 3 + Mathf.PI / 3), Mathf.Sin(Random.value * Mathf.PI / 3 + Mathf.PI / 3), 0) * Random.Range(500, 1000),
                Vector3.zero
            ) ;
        }
    }
}
