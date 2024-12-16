using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    public GameObject particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(particleSystem,transform.position,transform.rotation);
        other.GetComponent<HealthRobot>().getHit(10000000);
        Destroy(this.gameObject);
    }
}
