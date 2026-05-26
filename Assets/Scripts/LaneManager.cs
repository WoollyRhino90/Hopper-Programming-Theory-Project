using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
   
public float spawnInterval = 2f;
public float spawnPosX = -55f;
public float spawnPosZ = 0f;

    

//OLD: public static LaneManager SharedInstance;
public List<GameObject> pooledObjects;
public GameObject objectToPool;
public int amountToPool;

//OLD: void Awake()
//{
   // SharedInstance = this;
//}

void Start()
{
    pooledObjects = new List<GameObject>();
    for(int i = 0; i < amountToPool; i++)
    {
        GameObject tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
    }
    InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
}

public GameObject GetPooledObject()
{
    for(int i = 0; i < amountToPool; i++)
    {
        if(!pooledObjects[i].activeInHierarchy)
        {
            return pooledObjects[i];
            
        }
    }
    return null;
}

private void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(spawnPosX, 2, spawnPosZ);

        GameObject pooledEnemy = GetPooledObject();
        if (pooledEnemy != null)
        {
            Obsticle obsticleScript = pooledEnemy.GetComponent<Obsticle>();
            if (obsticleScript != null)
            {
                obsticleScript.laneManager = this;
            }
        
        pooledEnemy.transform.position = spawnPos;
        pooledEnemy.transform.rotation = objectToPool.transform.rotation;
        pooledEnemy.SetActive(true);
        }
    }
}


















            
         
   
   
