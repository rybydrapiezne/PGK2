using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupBattery : MonoBehaviour
{
    public float moveAmount = 1.5f;
    private void OnTriggerEnter(Collider other)
    {
        float time = 0.0f;
        other.gameObject.GetComponent<NavMeshAgent>().speed += moveAmount;
        Destroy(this.gameObject); 
    }
    
}

