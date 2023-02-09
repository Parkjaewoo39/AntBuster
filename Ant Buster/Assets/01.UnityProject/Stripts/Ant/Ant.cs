using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{

    public float maxHp = default;
    public float currenHp = default;
    public float antHeadRotate = 2;

    public float moveSpeed = default;
    public float guageAmount = default;

    private Rigidbody2D antRigidbody;
    private Image guageFront = default;
    private Vector2 direction = default;

    public GameObject targetCakePoint = default;
    public GameObject targetAntHome = default;
    private bool isCakeCheck = false;


    // Start is called before the first frame update

    public void Awake()
    {
        antRigidbody = GetComponent<Rigidbody2D>();
        currenHp = 2;
    }   //Awake()

    void Start()
    {
        isCakeCheck = false;
        guageFront = gameObject.GetComponentMust<Image>("AntHp");
        antRigidbody.velocity = transform.forward * moveSpeed;
    }   //Start()

    void Update()
    {
        guageAmount = currenHp / (float)maxHp;

        guageFront.fillAmount = guageAmount;

        if (!isCakeCheck)
        {
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetCakePoint.transform.position, 0.005f);
            GFunc.HeadRotate(gameObject, targetCakePoint, 3);
            //Vector2 direction = new Vector2
            //       (transform.position.x - targetCakePoint.transform.position.x,
            //       transform.position.y - targetCakePoint.transform.position.y);

            //float angle = Mathf.Atan2(direction.y, direction.x) *
            //    Mathf.Rad2Deg;

            //Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

            //Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, antHeadRotate *
            //    Time.deltaTime);

            //transform.rotation = rotation;
            //Debug.Log(isCakeCheck);
        }
        else 
        {           
            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetAntHome.transform.position, 0.005f);

            GFunc.HeadRotate(gameObject, targetAntHome, 3);
            //Vector2 direction = new Vector2
            //       (transform.position.x - targetAntHome.transform.position.x,
            //       transform.position.y - targetAntHome.transform.position.y);

            //float angle = Mathf.Atan2(direction.y, direction.x) *
            //    Mathf.Rad2Deg;

            //Quaternion angleAxis = Quaternion.AngleAxis(angle + 90f, Vector3.forward);

            //Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, antHeadRotate *
            //    Time.deltaTime);

            //transform.rotation = rotation;
        }
    }   //Update()


    public void Hit(int i)
    {
        currenHp -= i;
        Debug.Log($"hit");
        if (currenHp <= 0)
        {
            Die();
        }
    }   //Hit()


    public void Die()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        manager.ScoreAdd();
        //Invoke(Ant, 2f)
        currenHp += currenHp + Mathf.Floor(currenHp / 2);
    }       //Die()

    public void ScoreAdd()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cake")
        {
            isCakeCheck = true;          
        }
    }   //OnTriggerEnter2D()

}
