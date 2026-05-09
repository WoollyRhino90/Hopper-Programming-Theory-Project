using UnityEditor.Rendering;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject playerClone;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerClone != null)
            {
                Instantiate(playerClone, this.transform.position, this.transform.rotation);
                
            }
        }
        
        Destroy(gameObject);
        other.transform.position = new Vector3(0f,2f,-17f);
     
    }
}                                
