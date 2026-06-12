using System.Xml;
using UnityEngine;

public class Obsticle : MonoBehaviour
{

    public GameObject enemy;

    public float speed = 40.0f;

    public float destroyBound = 70f;
    protected Rigidbody rb;
    [HideInInspector] public LaneManager laneManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void OnEnable()
    {
       
            rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
    
        if (rb != null && rb.isKinematic == false)
        {
            rb.linearVelocity = Vector3.right * speed;
        }
        if (transform.position.x > destroyBound)
         {
            gameObject.SetActive(false);
         }
    }
}
