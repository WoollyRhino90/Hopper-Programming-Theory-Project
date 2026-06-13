using UnityEngine;

public class Carrot : MonoBehaviour
{
    public GameObject playerClone;
    public Vector3 spawnPoint;
    private PlayerController playerController;

    void Start()
    {
        playerController = Object.FindFirstObjectByType<PlayerController>();
        spawnPoint = new Vector3(0f,2f,-17f);
    }


   public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerClone != null)
            {

                Instantiate(playerClone, this.transform.position, this.transform.rotation);
                Debug.Log("Safe Bunny!");
            }
        }
        FindFirstObjectByType<UIManager>().CarrotCollected();
        Destroy(gameObject);
        other.transform.position = spawnPoint;
     
    }
}                                
