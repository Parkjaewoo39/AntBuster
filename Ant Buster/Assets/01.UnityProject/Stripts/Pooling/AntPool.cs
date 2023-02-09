using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static AntPool Instance;
    public int ObjectNumber;
    [SerializeField]
    private GameObject poolingObjectPrefab;
    public Canvas can;

    Queue<Ant> poolingObjectQueue = new Queue<Ant>();

    private void Awake()
    {
        Instance = this;

        Initialize(ObjectNumber);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public Ant CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Ant>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(can.transform, false);
        return newObj;
    }

    public Ant GetObject()
    {

        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(can.transform, false);
            return obj;
        }        
        else 
        {
            return null;            
        }
    }

    public static void ReturnObject(Ant obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }




}
