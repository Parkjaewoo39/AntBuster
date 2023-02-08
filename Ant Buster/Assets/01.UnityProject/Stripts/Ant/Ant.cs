using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    
    public static float Hp = default;
    public float moveSpeed = default;
    private Rigidbody2D bulletRigidbody;
    private Vector2 direction = default;
    // Start is called before the first frame update

    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        transform.LookAt(direction);
        bulletRigidbody.velocity = transform.forward * moveSpeed;
        
    }
    public void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        Hp = 2;
    }

    public void Hit()
    {
        --Hp;      
        if (Hp <= 0)
        {           
           
            Die();
            Hp += Hp + Mathf.Floor(Hp / 2 ) ;
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
