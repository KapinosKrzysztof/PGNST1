using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 2.0f;    
    Rigidbody rb;                 

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        float mH = Input.GetAxis("Horizontal");  
        float mV = Input.GetAxis("Vertical");    

        
        Vector3 movement = new Vector3(mH, 0, mV);
        
        
        movement = movement.normalized * speed * Time.deltaTime;

        
        rb.MovePosition(transform.position + movement);
    }
}

