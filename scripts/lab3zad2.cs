using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{

    public float speed = 2.0f;

    private Vector3 startPosition;
    private bool movingForward = true;

    public float maxDistance = 10.0f;

    void Start()
    {
        
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingForward)
        {

            transform.position += Vector3.right * speed * Time.deltaTime;

            if (Vector3.Distance(startPosition, transform.position) >= maxDistance)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            
            if (Vector3.Distance(startPosition, transform.position) <= 0.01f)
            {
                movingForward = true;
            }
        }
    }
}
