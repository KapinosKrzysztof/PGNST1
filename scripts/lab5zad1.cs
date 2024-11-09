using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float platformSpeed = 2f;
    public float distance = 10f;
    private bool isMoving = false;
    private bool isMovingToTarget = true;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Transform oldParent;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.right * distance;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (isMovingToTarget && Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                isMovingToTarget = false;
                StartCoroutine(WaitBeforeMovingBack());
            }
            else if (!isMovingToTarget && Vector3.Distance(transform.position, startPosition) < 0.1f)
            {
                isMoving = false;
                isMovingToTarget = true;
            }

            Vector3 direction = isMovingToTarget ? (targetPosition - transform.position).normalized : (startPosition - transform.position).normalized;
            transform.Translate(direction * platformSpeed * Time.fixedDeltaTime);
        }
    }

    private IEnumerator WaitBeforeMovingBack()
    {
        yield return new WaitForSeconds(1f); 
        isMoving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("gracz wszedł na platformę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            isMoving = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("gracz zszedł z platformy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
