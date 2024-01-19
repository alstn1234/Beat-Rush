using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject _notePrefab;
    public int poolSize = 50;

    public Queue<GameObject> poolQueue = new Queue<GameObject>();

    private void Awake()
    {
        Managers.Pool = this;
    }
    public void SetPool()
    {
        _notePrefab = Resources.Load<GameObject>("Ghost");
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Managers.Resource.Instantiate("Assets/@Resources/Prefabs/Note/Ghost.prefab",transform);
            //obj.transform.SetParent(transform);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    public GameObject SpawnFromPool()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(false );
            poolQueue.Enqueue(obj);
            obj.SetActive(true);
            return obj;
        }
        else return null;
    }

    public List<GameObject> GetActiveNotes()
    {
        List<GameObject> activepool = new List<GameObject>();
        foreach (GameObject obj in poolQueue)
        {
            if (obj.activeSelf == true && obj.transform.position.z >= 10)
            {
                activepool.Add(obj);
            }
            activepool.OrderBy(x => x.transform.position.z).ToList();
        }
        return activepool;
    }
}