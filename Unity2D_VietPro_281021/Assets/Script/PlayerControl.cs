using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D playerRb;

    public Animator anim;

    public SpriteRenderer playerSprite;

    public bool onGround;//đang đứng trên các đối tượng va chạm cứng - được phép nhảy và di chuyển

    public int countJump = 0;//

    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;

    HeathBar heathBar;
    TMP_Text heathPoint;

    // Start is called before the first frame update
    void Start()
    {
        uiControl = GameObject.Find("Canvas").GetComponent<UIControl>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        heathBar = transform.GetChild(0).GetComponent<HeathBar>();
        heathPoint = transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>();
        heathPoint.text = heathBar.maxHeath.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetupCollider();

        if (heathBar.heath == 0)
        {
            anim.SetBool("death", true);
        }
    }

    public void Move()
    {
        if (uiControl.moveLeft == true || Input.GetKey(KeyCode.LeftArrow))
        {
            if (onGround == true)
            {
                uiControl.moveLeft = true;
                //Debug.Log("--->Chay");
                playerRb.transform.Translate(Vector2.left * 5 * Time.deltaTime);
                playerSprite.flipX = true;
                anim.SetBool("run", true);
            }
        }
        if (uiControl.moveRight == true || Input.GetKey(KeyCode.RightArrow))
        {

            if (onGround == true)
            {
                uiControl.moveRight = true;
                //Debug.Log("Chay");
                playerRb.transform.Translate(Vector2.right * 5 * Time.deltaTime);
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
                //Debug.Log("Nhay lan 1");
                anim.SetBool("jump", true);

                if (uiControl.moveRight == true)
                {
                    //Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(1 * 200, 1 * 500));
                }
                if (uiControl.moveLeft == true)
                {
                    //Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(-1 * 200, 1 * 500));
                }
                if (uiControl.moveLeft == false && uiControl.moveRight == false)
                {
                    //Debug.Log("Jump khi dang dung yen");
                    playerRb.AddForce(new Vector2(0, 1 * 500));
                }

                countJump = 1;
            }
            if (countJump == 1 && onGround == false)
            {
                //Debug.Log("Nhay lan 2");
                anim.SetBool("jump", true);

                if (uiControl.moveRight == true)
                {
                    //Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(1 * 100, 1 * 400));
                }
                if (uiControl.moveLeft == true)
                {
                    //Debug.Log("Jump khi dang di chuyen");
                    playerRb.AddForce(new Vector2(-1 * 200, 1 * 400));
                }
                if (uiControl.moveLeft == false && uiControl.moveRight == false)
                {
                    //Debug.Log("Jump khi dang dung yen");
                    playerRb.AddForce(new Vector2(0, 1 * 400));
                }

                countJump = 2;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Debug.Log("Dung di chuyen");
            uiControl.moveLeft = false;
            uiControl.moveRight = false;
            anim.SetBool("run", false);
        }



        if (uiControl.roll == true)
        {
            if (uiControl.moveLeft == true || uiControl.moveRight == true)
            {
                anim.SetBool("roll", true);
            }
        }
        else
        {
            anim.SetBool("roll", false);
        }
    }

    public void SetupCollider()
    {
        if (anim.GetBool("roll") == true)
        {
            circleCollider.enabled = true;
            boxCollider.enabled = false;
        }
        else
        {
            circleCollider.enabled = false;
            boxCollider.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("jump", false);
        }

        if (collision.gameObject.tag == "Saw")
        {
            anim.SetBool("death", true);
            this.GetComponent<PlayerControl>().enabled = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("Va cham cung voi " + collision.gameObject.name);
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
        //Debug.Log("Kết thúc va chạm cứng với " + collision.gameObject.name);
        onGround = false;
        anim.SetBool("ground", false);

        if (collision.gameObject.name == "DiChuyen")
        {
            transform.SetParent(collision.gameObject.transform.parent.gameObject.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            //Debug.Log("Va chạm mềm với Cánh cửa");
        }

        if (collision.tag == "Coin")
        {
            Destroy(collision.gameObject);
            uiControl.coin += 30;
            PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin") + 30);
            uiControl.gameObject.SendMessage("ShowCoin", PlayerPrefs.GetInt("Coin"));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            //Debug.Log("Kết thúc va chạm mềm với Cánh cửa");
        }

        if (collision.tag == "Demon")
        {
            if (heathBar.heath >= 10)
            {
                heathBar.SetHeath(10);

            }
            else
            {
                heathBar.SetHeath(heathBar.heath);
            }
            heathPoint.text = heathBar.heath.ToString();
        }
    }
}
