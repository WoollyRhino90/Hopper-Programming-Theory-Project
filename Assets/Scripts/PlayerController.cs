using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

private float xRange = 38;
private float zRange = 17;
private float yRange = -5;

public string enemyTag = "Enemy";
public Vector3 spawnPoint;

public float hopDistance = 1f;
public float hopSpeed = 10f;
private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
    //Limit character bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.y < yRange)
        {
            transform.position = spawnPoint;
            Debug.Log("You Drowned!!");
        }

    //Movement
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Hop(Vector3.forward);
        } 
       if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Hop(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Hop(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Hop(Vector3.back);
        }
    }

void Hop(Vector3 direction)
    {
        rb.MovePosition(rb.position + direction * hopDistance);
    }
    // Reset position to start if hit enemy
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
           transform.position=spawnPoint;
            Debug.Log("You Died!");
        }
    }

    // Ride with log if on log
void OnCollisionEnter(Collision other)
{
    if (other.gameObject.CompareTag("Log"))
        transform.SetParent(other.transform);
        Debug.Log("Log");
}

void OnCollisionExit(Collision other)
{
    if (other.gameObject.CompareTag("Log"))
        transform.SetParent(null);
}
}
