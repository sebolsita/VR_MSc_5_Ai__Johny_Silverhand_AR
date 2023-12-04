using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementPlayer : MonoBehaviour
{
    public GameObject playerObject;

    public float movementSpeed;
    public float turnSpeed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerObject.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerObject.transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerObject.transform.Rotate(Vector3.up, -turnSpeed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerObject.transform.Rotate(Vector3.up, turnSpeed);
        }
    }
}