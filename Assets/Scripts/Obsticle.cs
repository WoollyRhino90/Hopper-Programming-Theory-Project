using System.Xml;
using UnityEngine;

public class Obsticle : MonoBehaviour
{

    public GameObject enemy;
    //public float spawnPosZ;
    //public float spawnPosX = -55;
    //public float startDelay = 2f;
    //public float spawnInterval;

    public float speed = 40.0f;

    public float destroyBound = 70f;
    private Rigidbody rb;
    [HideInInspector] public LaneManager laneManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void OnEnable()
    {
       
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
}
