using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    UIControl uiControl;

    public Rigidbody2D playerRb;

    public Animator playerAnim;

    public SpriteRenderer playerSprite;

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
            playerRb.velocity = new Vector2(-50f * Time.deltaTime, 0f);
            playerSprite.flipX = true;
            playerAnim.Play("walk");

        }
        if (uiControl.moveRight == true)
        {
            playerRb.velocity = new Vector2(50f * Time.deltaTime, 0f);
            playerSprite.flipX = false;
            playerAnim.Play("walk");
        }
        if (uiControl.jump == true)
        {
            playerRb.velocity = new Vector2(0f, 12f);
            uiControl.jump = false;
        }
    }
}
