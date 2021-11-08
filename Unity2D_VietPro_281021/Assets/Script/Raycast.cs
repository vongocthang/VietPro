using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject doiTuong;
    //Ray ray;
    //RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log("OK");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Tia raycast " + hit.transform.gameObject.tag);
                if (hit.transform.gameObject.tag == "DoiTuong")
                {
                    Debug.Log("Va vao doi tuong");
                    doiTuong = hit.transform.gameObject;
                    return;
                }
                if (doiTuong != null && hit.transform.gameObject.tag == "Untagged")
                {
                    Debug.Log("Di chuyen doi tuong");
                    
                    doiTuong.transform.position = hit.point;
                }
            }

            
        }
    }

    public void ChonDoiTuong()
    {
        Debug.Log("OK");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log("Tia raycast");
            if (hit.transform.tag == "DoiTuong")
            {
                Debug.Log("Va vao doi tuong");
                doiTuong = hit.transform.gameObject;
                return;
            }
        }

        DiChuyenDoiTuong();
    }

    public void DiChuyenDoiTuong()
    {
        if (doiTuong != null)
        {
            Debug.Log("Di chuyen doi tuong");
            doiTuong.transform.position = Input.mousePosition;
        }
    }
}
