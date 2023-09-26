using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public static ObjectPool instance;

    private List<GameObject> pool = new List<GameObject>();
    private int cantidadBalas = 30;

    [SerializeField] private GameObject balaPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i < cantidadBalas; i++)
        {
            GameObject obj = Instantiate(balaPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
        
    }

    public GameObject GetBalaPrefab()
    {
        for(int i=0; i< pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        return null;
    }
}
