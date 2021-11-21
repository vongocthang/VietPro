using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public bool moveLeft;
    public bool moveRight;
    public bool jump;
    public bool roll;
    PlayerControl player;

    public int countClick = 0;//Đếm doubleClick
    public float timeLineClick;//

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExitDoubleClick();
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }

    public void MoveRight()
    {
        moveRight = true;
    }

    public void NotMove()
    {
        moveLeft = false;
        moveRight = false;
    }

    public void Jump()
    {
        jump = true;
    }


    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DoubleClick()
    {
        if (countClick < 2)
        {
            countClick++;
            //Debug.Log("Click lan " + countClick);
            timeLineClick = Time.time;
        }
        if (countClick == 2)
        {
            //Debug.Log("DoubleClick thanh cong");
            roll = true;
            timeLineClick = Time.time;
        }
    }

    public void ExitDoubleClick()
    {
        if (countClick < 2)
        {
            if (timeLineClick + 0.2f < Time.time)
            {
                //Debug.Log("Reset doubleClick");
                countClick = 0;
            }
        }

        if (roll == true)
        {
            if (timeLineClick + 1.9f < Time.time)
            {
                //Debug.Log("Hanh dong cuon kich hoat");
                countClick = 0;
                roll = false;
            }
        }
    }
}
