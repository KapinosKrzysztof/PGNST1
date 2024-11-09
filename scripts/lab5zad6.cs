using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("przeszkoda"))
        {
            Debug.Log("Gracz wszedł w kontakt z przeszkodą!");
        }
    }
}
