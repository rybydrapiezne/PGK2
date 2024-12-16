using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShield : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<HealthRobot>().getShielded();
        Destroy(this.gameObject);
    }
}
