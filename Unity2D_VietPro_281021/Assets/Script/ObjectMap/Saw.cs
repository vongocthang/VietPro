using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public bool directionRotate = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (directionRotate == false)
        {
            this.transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
        }
        else
        {
            this.transform.Rotate(Vector3.back * 1 * Time.deltaTime);
        }
    }
}
