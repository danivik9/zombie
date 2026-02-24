using UnityEngine;

public class Collectible : MonoBehaviour
{
   private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}