using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDropUI : MonoBehaviour
{
    public bool onUI = false;
    public bool drag = false;
    Camera cam;
    public RectTransform rect;
    public RectTransform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (drag == true)
        {
            Debug.Log("start drag: ");
            Debug.Log("mouse: " + Input.mousePosition);
            //this.transform.position = cam.i(Input.mousePosition);
            rect.anchoredPosition = (Input.mousePosition);
            Debug.Log("UI: " + Input.mousePosition);
        }
        if (drag == false)
        {
            Vector3 a = rect.anchoredPosition;
            Vector3 b = target.anchoredPosition;
            if (Vector3.Distance(a, b) <= 100)
            {
                rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, target.anchoredPosition, 
                    5 * Time.deltaTime);
                Debug.Log("Ghep vao");
            }
            //rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, target.anchoredPosition, 1);
        }
    }

    public void Drag()
    {
        drag = true;
    }

    public void EndDraw()
    {
        drag = false;
    }
}
