using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Bullet : MonoBehaviour
{    
    public float bulletSpeed = 30f;
    private Rigidbody2D bulletRigid;
    private Vector2 direction = default;
    
    public void Awake()
    {
        bulletRigid = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {

        transform.Translate(Vector2.up*Time.deltaTime);
        Invoke("DestroyBullet", 2f);
    }

    public void DestroyBullet()
    {
        TowerBulletPool.ReturnObject(this);
        CancelInvoke();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ant")
        {
            Ant ant = other.GetComponent<Ant>();
            ant.Hit();
            Invoke("DestroyBullet", 0f);
        }

    }

    //public void OnTriggerExit2D(Collider2D other)
    //{
    //    var bullet = TowerBulletPool.GetObject();

    //    if (other.tag == "TowerRange")
    //    {

    //        TowerBulletPool.ReturnObject(bullet);
    //    }
    //}
    //void Update()
    //{
    //    transform.Translate(direction);
    //}
}
