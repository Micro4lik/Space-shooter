using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPool : Singleton<ManagerPool>
{
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;

    public List<GameObject> bulletlist;
    public List<GameObject> enemylist;
    
    public void initializePool(int size, GameObject prefab, List<GameObject> objList)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.parent = gameObject.transform;
            obj.SetActive(false);
            objList.Add(obj);
        }
    }

    void Awake()
    {
        initializePool(15, bulletPrefab, bulletlist);
        initializePool(20, enemyPrefab, enemylist);
    }
    
}
