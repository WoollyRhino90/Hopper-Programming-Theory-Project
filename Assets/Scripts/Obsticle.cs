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
    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
            InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
            rb = GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.right * speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //OLD: transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);

        if (transform.position.x > destroyBound)
         {
            gameObject.SetActive(false);
         }
    }

    protected void SpawnEnemy()
    {
   
        Vector3 spawnPos = new Vector3(spawnPosX, 2, spawnPosZ);
        //OLD: Instantiate(enemy, spawnPos, enemy.transform.rotation);

        GameObject gameObject = LaneManager.SharedInstance.GetPooledObject(); 
        if (gameObject != null) 
        {
            gameObject.transform.position = spawnPos;
            gameObject.transform.rotation = enemy.transform.rotation;
            gameObject.SetActive(true);
        }
    }
}
