using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D playerRb;

    public Animator playerAnim;

    public SpriteRenderer playerSprite;

    public bool onGround;//đang đứng trên các đối tượng va chạm cứng - được phép nhảy và di chuyển

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
                playerRb.transform.Translate(Vector2.left * 2 * Time.deltaTime);
                playerSprite.flipX = true;

                playerAnim.SetBool("run", true);
                playerAnim.SetBool("jump", false);
            }
        }
        if (uiControl.moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {
            if (onGround == true)
            {
                playerRb.transform.Translate(Vector2.right * 2 * Time.deltaTime);
                playerSprite.flipX = false;

                playerAnim.SetBool("run", true);
                playerAnim.SetBool("jump", false);
            }
        }
        if (uiControl.jump == true || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Ok");
            if (onGround == true)
            {
                Debug.Log("Jump");
                playerRb.AddForce(Vector2.up * 500);
            }
        }


        if (uiControl.moveLeft == false && uiControl.moveRight == false)
        {
            playerAnim.SetBool("run", false);
        }

        if (playerRb.velocity.y == 0)
        {
            playerAnim.SetBool("jump", false);
            uiControl.jump = false;
        }

        if (playerRb.velocity.y > 0)
        {
            playerAnim.SetBool("run", false);
            playerAnim.SetBool("jump", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Va chạm cứng với Thùng hóa chất");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Kết thúc va chạm cứng với Thùng hóa chất");
        }
        onGround = false;
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
