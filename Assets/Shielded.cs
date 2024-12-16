using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shielded : MonoBehaviour
{
    float time = 0.0f;
    public float endTime=3.0f;
    public GameObject owner;
    void Update()
    {
        if(time>endTime)
        {
            owner.GetComponent<HealthRobot>().isShielded = false;
            Destroy(this.gameObject);
        }
        time += Time.deltaTime;
    }
}
