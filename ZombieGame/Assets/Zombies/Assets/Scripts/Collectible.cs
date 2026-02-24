using UnityEngine;

public class Collectible : MonoBehaviour
{
    
   private GameManager gameManager;
   void Start()
   {
       gameManager = FindObjectOfType<GameManager>();
   }
   private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            gameManager.AddCoin(); 
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}