using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRobot : MonoBehaviour
{
    public int health = 10;
    public bool isShielded = false;
    public GameObject shield;
    public GameObject particleSystem;
    public void getHit(int amount)
    {
        if (!isShielded)
        {
            health -= amount;
            Instantiate(particleSystem, this.transform.position, this.transform.rotation);
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void getShielded()
    {
        isShielded=true;
        GameObject shielded=GameObject.Instantiate(shield,transform.position,transform.rotation);
        shielded.transform.parent=this.transform;
        shielded.GetComponent<Shielded>().owner = this.gameObject;
    }

}
