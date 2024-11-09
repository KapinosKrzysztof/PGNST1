using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float doorSpeed = 3f; 
    public float openDistance = 5f; 
    private Vector3 closedPosition; 
    private Vector3 openPosition;
    private bool isOpening = false; 
    private bool isClosing = false; 

    void Start()
    {
        
        closedPosition = transform.position;
        openPosition = closedPosition + transform.right * openDistance;
    }

    void Update()
    {
        
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, openPosition) < 0.1f)
            {
                isOpening = false;
            }
        }
       
        else if (isClosing)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, doorSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, closedPosition) < 0.1f)
            {
                isClosing = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player jest blisko drzwi, otwieram je.");
            isOpening = true;
            isClosing = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player odszedł od drzwi, zamykam je.");
            isClosing = true;
            isOpening = false;
        }
    }
}
