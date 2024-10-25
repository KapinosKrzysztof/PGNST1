using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSquarePattern : MonoBehaviour
{
    public float speed = 2.0f;       
    public float sideLength = 10.0f; 
    public float rotationSpeed = 360.0f; 
    
    private Vector3 startPosition;   
    private int currentCorner = 0;   
    private bool isRotating = false; 
    private Quaternion targetRotation;
    private Vector3[] directions;    

    void Start()
    {
      
        startPosition = transform.position;

      
        directions = new Vector3[]
        {
            transform.right,    
            transform.forward,  
            -transform.right,  
            -transform.forward 
        };

       
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (isRotating)
        {
            
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
                startPosition = transform.position; 
            }
        }
        else
        {
            
            transform.position += directions[currentCorner] * speed * Time.deltaTime;

          
            if (Vector3.Distance(startPosition, transform.position) >= sideLength)
            {
                
                currentCorner = (currentCorner + 1) % 4; 
                targetRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, -90, 0));

                
                isRotating = true;
            }
        }
    }
}
