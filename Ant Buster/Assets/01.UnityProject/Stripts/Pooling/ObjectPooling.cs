using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public int ObjectNumber;
    [SerializeField]
    private GameObject poolingObjectPrefab;

    Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

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

    private Bullet CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Bullet>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Bullet GetObject()
    {
        
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            GameObject parent = GFunc.GetRootObj("GameObject");
            parent.FindChildObj("TowerBulletSpawn");
            obj.transform.SetParent(parent.transform);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            //var newObj = Instance.CreateNewObject();
            //newObj.gameObject.SetActive(true);
            //newObj.transform.SetParent(null);
            return null;
        }

    }

    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
