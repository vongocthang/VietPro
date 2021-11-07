using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropUI : MonoBehaviour
{
    public bool onUI = false;
    public bool drag = false;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (drag == true)
        {
            Debug.Log("start drag");
          //  this.transform.position = cam.i(Input.mousePosition);
           this.transform.position = (Input.mousePosition);
        }
    }

    public void Drag()
    {
        drag = true;
    }


}
