using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AntShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject antSpawner;
    public GameObject antPrefabs;
    public GameObject targetCake = default;
    public float spawnRate = default;
    public GameObject ant;
    AntPool antPool;

    public int rotateSpeed;
    //public Transform target;

    //private Transform target_;
    private float spawnRate_;
    private float timeAfterSpawn;

    public bool isSetCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        isSetCheck = false;
        spawnRate_ = spawnRate;
        antPool = ant.GetComponent<AntPool>();
        //if (FindObjectOfType<Ant>() != null)
        //{
        //    target = FindObjectOfType<Ant>().transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
       // GFunc.HeadRotate(gameObject, targetCake, 2f);

        timeAfterSpawn += Time.deltaTime;
        Vector2 pos = this.transform.position;
        if (timeAfterSpawn >= spawnRate_)
        {
            timeAfterSpawn = 0f;
            //Debug.Log($"{timeAfterSpawn}");
            

            var direction = targetCake.transform.position;
            var ant = antPool.GetObject();
           
            ant.transform.position = pos;
            ant.transform.rotation = transform.rotation;
          
        }
        
    }   //Update()
}
   
    