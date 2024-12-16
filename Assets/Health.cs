using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health=500;
    public HealthBar healthBar;
    void Start()
    {
        healthBar.SetMaxHealth(health);     
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(health);
    }
}
