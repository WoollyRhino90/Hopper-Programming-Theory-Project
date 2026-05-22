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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            transform.Translate(Vector3.forward*4);
        } 
       if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left*2);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right*2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back*4);
        }
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


}
