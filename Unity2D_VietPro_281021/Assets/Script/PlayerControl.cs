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
        if (uiControl.moveLeft == true)
        {
            if (onGround == true)
            {
                playerRb.velocity = new Vector2(-80f * Time.deltaTime, 0f);
                playerSprite.flipX = true;

                playerAnim.SetInteger("check", 1);
            }
        }
        if (uiControl.moveRight == true)
        {
            if (onGround == true)
            {
                playerRb.velocity = new Vector2(80f * Time.deltaTime, 0f);
                playerSprite.flipX = false;

                playerAnim.SetInteger("check", 1);
            }
        }
        if (uiControl.jump == true)
        {
            if (onGround == true)
            {
                playerRb.velocity = new Vector2(0f, 12f);

                playerAnim.SetInteger("check", 3);
            }
            uiControl.jump = false;
        }


        if (uiControl.moveLeft == false && uiControl.moveRight == false)
        {
            playerAnim.SetInteger("check", 0);
        }
    }
}
