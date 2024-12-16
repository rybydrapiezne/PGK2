using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCameraC : MonoBehaviour
{
    [SerializeField]
    float speed = 1.0f;
    [SerializeField]
    CharacterController controller;

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        Vector3 move = Vector3.left * x - Vector3.back * z;

        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(Vector3.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftControl))
        {
            controller.Move(Vector3.down * speed * Time.deltaTime);
        }
    }
}
