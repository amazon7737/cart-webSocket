using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed = 5f;
    private float turnspeed = 45.0f;
    private float forwardInput;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = 0;
        horizontalInput = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            forwardInput = 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            forwardInput = -1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }

        if (forwardInput != 0){
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
                if (horizontalInput != 0){
                transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalInput);
            }
        }
    }
}
