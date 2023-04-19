using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collidercheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered");
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("Hi");
        }
    }

}

