using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    //public GameObject normalTowerPre;
    //public Transform parent;

    public GameObject translucent = null;
    private GameObject creatTranslucent = null;
    public GameObject realTower = null;

    public bool isClick = false;

    public GameObject gameObjs = default;


    // Start is called before the first frame update
    void Start()
    {
        isClick = false;

        gameObjs = GFunc.GetRootObj("GameObject");

    }

    // Update is called once per frame
    void Update()
    {
        //MouseBtnInput();
        

    }

    public void OnMouseDown()
    {
        if (!isClick)
        {

        }
        isClick = true;
        creatTranslucent = Instantiate(translucent, transform);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePos.z = 1f;

        creatTranslucent.transform.position = mousePos;
    }

    public void OnMouseDrag()
    {
        if (isClick == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
                mousePos.z = 1f;
                creatTranslucent.transform.position = mousePos;
        }
    }

    public void OnMouseUp()
    {

        isClick = false;
        //Debug.Log($"{Input.mousePosition}");        

        //creatTranslucent = Instantiate(translucent,transform.position, Quaternion.identity);
        //creatTranslucent.transform.SetParent(this.transform);
        
        Instantiate(realTower, creatTranslucent.transform.position, Quaternion.identity, gameObjs.transform);
        Destroy(creatTranslucent);

    }

    
    
}
