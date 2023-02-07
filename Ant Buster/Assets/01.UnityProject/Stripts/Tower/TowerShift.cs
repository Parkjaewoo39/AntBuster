using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShift : MonoBehaviour
{
    public GameObject NormalTower = null;
    public GameObject HeavyTower = null;

    public int[] MakeMap = new int[260];

    // Start is called before the first frame update
    void Start()
    {
        Vector3 setPos = new Vector3(6.7f, 0.7f, 0);
        Instantiate(NormalTower, setPos, Quaternion.identity);

      //  MakeMap = GameObject.FindGameObjectWithTag("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
