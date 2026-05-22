using System.Xml;
using UnityEngine;

public class Obsticle : MonoBehaviour
{

    public GameObject enemy;
    public float spawnPosZ;
    public float spawnPosX = -55;
    public float startDelay = 2f;
    public float spawnInterval;

    public float speed = 40.0f;

    public float destroyBound = 70f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
    
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);

        if (transform.position.x > destroyBound)
         {
             Destroy(gameObject);
         }
    }

    protected void SpawnEnemy()
    {
   
        Vector3 spawnPos = new Vector3(spawnPosX, 2, spawnPosZ);
        Instantiate(enemy, spawnPos, enemy.transform.rotation);
    }
}
