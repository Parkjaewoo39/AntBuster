using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerBulletShooter : MonoBehaviour
{
    public GameObject bulletSpawner;
    public GameObject bulletPrefabs;
    public float spawnRate = default;

    public int rotateSpeed;
    //public Transform target;

    //private Transform target_;
    private float spawnRate_;
    private float timeAfterSpawn;

    public bool isSetCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 1f;
        isSetCheck = false;
        spawnRate_ = spawnRate;
        //if (FindObjectOfType<Ant>() != null)
        //{
        //    target = FindObjectOfType<Ant>().transform;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
    }   //Update()
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ant")
        {
            isSetCheck = true;
            if (other != null)
            {
                Vector2 direction = new Vector2
                    (transform.position.x - other.transform.position.x,
                    transform.position.y - other.transform.position.y);

                float angle = Mathf.Atan2(direction.y, direction.x) *
                    Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed *
                    Time.deltaTime);
                transform.rotation = rotation;

            }

            timeAfterSpawn += Time.deltaTime;
            Vector2 pos = this.transform.position;
            if (timeAfterSpawn >= spawnRate_)
            {
                timeAfterSpawn = 0f;
                //Debug.Log($"{timeAfterSpawn}");

                var direction = other.transform.position;

                var bullet = TowerBulletPool.GetObject();

                bullet.transform.position = pos;
                bullet.transform.rotation = transform.rotation;

                //TowerBulletPool.ReturnObject(bullet);   
                // TowerBulletPool.ReturnObject(bullet);
            }
        }
        
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        isSetCheck= false;
    }









}
