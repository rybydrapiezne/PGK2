using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public int amount=10;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Spawner").GetComponent<Spawn>().coins += amount;
        Destroy(this.gameObject);
    }
}
