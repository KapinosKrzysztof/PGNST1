using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchMultiplier = 3f;

    private void OnTriggerEnter(Collider other)
    {
       
        Debug.Log("Trigger Entered by: " + other.name);

        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the pressure plate!");

           
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
               
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0, playerRb.velocity.z);

                
                float launchForce = playerRb.mass * Physics.gravity.magnitude * launchMultiplier;
                playerRb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);

                
               
            }
            else
            {
                Debug.LogWarning("No Rigidbody found on the player!");
            }
        }
    }
}
