using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roatate : MonoBehaviour
{
    public float speed=10f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.left * speed * Time.deltaTime);
    }
}
