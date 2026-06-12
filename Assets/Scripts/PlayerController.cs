using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

private float xRange = 38;
private float zRange = 17;
private float yRange = -2;

public string enemyTag = "Enemy";
public Vector3 spawnPoint;

public bool isOnGround = true;
public bool gameOver = false;
private bool onSafeSpot = false;

public float hopDistance = 1f;
//public float hopSpeed = 10f;
private Rigidbody rb;
private LogController currentLog = null;
private UIManager uiManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnPoint = transform.position;   
        uiManager = FindFirstObjectByType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
    //check for ground
         isOnGround = Physics.Raycast(transform.position, Vector3.down, 1.1f);

    //move with current log
        if (currentLog != null)
        {
            transform.position += currentLog.CurrentVelocity * Time.deltaTime;
        }
    

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
    // drown if fall below ground
        if (transform.position.y < yRange)
        {
            transform.position = spawnPoint;
            Debug.Log("You Drowned!!");
            FindFirstObjectByType<UIManager>().LifeLost();
        }

    //Movement

    if (isOnGround || currentLog != null)
        {
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
    }

void Hop(Vector3 direction)
    {
        if (!uiManager.isGameActive) return;
         transform.position += direction * hopDistance;
        //old movement: rb.MovePosition(rb.position + direction * hopDistance);
    }
   
    void OnTriggerEnter(Collider other)
    {
// set current log and ride on it
        LogController log = other.GetComponentInParent<LogController>();
        if (log != null)
        {
            currentLog = log;
            return;
        }
 // Reset position to start if hit enemy
        if (other.CompareTag(enemyTag))
        {
           transform.position=spawnPoint;
           FindFirstObjectByType<UIManager>().LifeLost();
           Debug.Log("You Died!");
        }
// move player to center of safespot if partially on it; not currently working
        if (other.CompareTag("SafeSpot"))
        {
            onSafeSpot = true;
            Vector3 center = other.bounds.center;
            transform.position = new Vector3(center.x, transform.position.y, center.z);
            Debug.Log("Safe");
        }
                
    }
    void OnTriggerExit(Collider other)
    {
        LogController log = other.GetComponentInParent<LogController>();
        if (log != null && log == currentLog)
        {
            currentLog = null;
        }

        if (other.CompareTag("SafeSpot"))
        {
            onSafeSpot = false;
        }
    }


 }
