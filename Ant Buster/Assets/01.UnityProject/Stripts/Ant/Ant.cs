using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    
    public static int Hp = default;
    public float moveSpeed = default;
    private Rigidbody2D bulletRigidbody;
    private Vector3 direction = default;
    // Start is called before the first frame update

    public void Shoot(Vector3 direction)
    {
        this.direction = direction;
        transform.LookAt(direction);
        bulletRigidbody.velocity = transform.forward * moveSpeed;
        
    }
    public void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    public void Hit()
    {
        --Hp;      
        if (Hp <= 0)
        {           
           
            Die();
        }
    }
    public void Die() 
    {
        GameManager manager = FindObjectOfType<GameManager>();
        manager.ScoreAdd();
    }
    public void ScoreAdd() 
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
