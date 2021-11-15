using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D playerRb;

    public Animator anim;

    public SpriteRenderer playerSprite;

    public bool onGround;//đang đứng trên các đối tượng va chạm cứng - được phép nhảy và di chuyển

    public int countJump = 0;//

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("Canvas").GetComponent<UIControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (uiControl.moveLeft == true || Input.GetKey(KeyCode.LeftArrow))
        {
            if (onGround == true)
            {
                Debug.Log("--->Chay");
                playerRb.transform.Translate(Vector2.left * 3 * Time.deltaTime);
                playerSprite.flipX = true;
                anim.SetBool("run", true);
            }    
        }
        if (uiControl.moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {
            if (onGround == true)
            {
                Debug.Log("Chay");
                playerRb.transform.Translate(Vector2.right * 3 * Time.deltaTime);
                playerSprite.flipX = false;
                anim.SetBool("run", true);
            }
        }

        if (uiControl.jump == true || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (countJump == 0 && onGround == false)
            {
                countJump = 1;
            }
            //Nhảy lần đầu cần đứng trên bề mặt cứng
            if (countJump == 0 && onGround == true)
            {
                Debug.Log("Nhay lan 1");
                anim.SetBool("jump", true);
                
                if (uiControl.moveRight == true)
                {
                    Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(1 * 100, 1 * 600));
                }
                if (uiControl.moveLeft == true)
                {
                    Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(-1 * 100, 1 * 600));
                }
                if (uiControl.moveLeft == false && uiControl.moveRight == false)
                {
                    Debug.Log("Jump khi dang dung yen");
                    playerRb.AddForce(new Vector2(0, 1 * 600));
                }

                countJump = 1;
            }
            if (countJump == 1 && onGround == false)
            {
                Debug.Log("Nhay lan 2");
                anim.SetBool("jump", true);
                
                if (uiControl.moveRight == true)
                {
                    Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(1 * 100, 1 * 300));
                }
                if (uiControl.moveLeft == true)
                {
                    Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(-1 * 100, 1 * 300));
                }
                if (uiControl.moveLeft == false && uiControl.moveRight == false)
                {
                    Debug.Log("Jump khi dang dung yen");
                    playerRb.AddForce(new Vector2(0, 1 * 300));
                }

                countJump = 2;
            }
        }

        if (uiControl.moveLeft == false && uiControl.moveRight == false)
        {
            Debug.Log("Dung di chuyen");
            anim.SetBool("run", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Va cham cung voi " + collision.gameObject.name);
        onGround = true;
        uiControl.jump = false;
        anim.SetBool("ground", true);
        

        countJump = 0;

        if (collision.gameObject.name == "DiChuyen")
        {
            transform.SetParent(collision.gameObject.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Kết thúc va chạm cứng với " + collision.gameObject.name);
        onGround = false;
        anim.SetBool("ground", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            Debug.Log("Va chạm mềm với Cánh cửa");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            Debug.Log("Kết thúc va chạm mềm với Cánh cửa");
        }
    }
}
