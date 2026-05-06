using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward*2);
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
            transform.Translate(Vector3.back*2);
        }
    }
}
