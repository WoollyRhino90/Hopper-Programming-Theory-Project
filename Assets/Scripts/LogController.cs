using UnityEngine;

public class LogController : Obsticle //INHERITANCE


{
    public Vector3 CurrentVelocity => Vector3.right * speed;

    protected override void OnEnable()
    {
        base.OnEnable();
        rb.isKinematic = true;
        rb.useGravity = false;
    }
   
      
    // Update is called once per frame
    protected override void Update() //POLYMORPHISM
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        if (transform.position.x > destroyBound)
        {
            gameObject.SetActive(false);
        }
    }
}
