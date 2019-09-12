using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObj : MonoBehaviour
{
    public float rotationleft = 360;
    public float rotationSpeed = 10;
    public float rotation;

    void Start()
    {
        
    }
    
    void Update()
    {
        //float rotation = rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.R))
        {
            rotation = rotationSpeed * Time.deltaTime;
            //}

            if (rotationleft > 0)
            {
                rotationleft -= rotation;
            }
            else
            {
                rotation = rotationleft;
                rotationleft = 0;
            }

            //transform.Rotate(Vector3.up, Time.deltaTime * speed);
            transform.Rotate(0, rotation, 0);
        }
        /*스냅회전이동(순간이동)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stop = true;
            if (stop == true)
            {
                Vector3 rotationObj = new Vector3(0, 0, 90);
                transform.Rotate(rotationObj);
            }
            stop = false;
        }
        */
    }
}
