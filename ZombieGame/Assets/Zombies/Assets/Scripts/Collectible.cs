using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // check if a zombie touched the coin
        if (other.CompareTag("Zombie"))
        {
            // destroy the coin
            Destroy(gameObject);
        }
    }
}