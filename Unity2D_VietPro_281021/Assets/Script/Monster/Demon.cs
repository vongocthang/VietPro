using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    VungPhatHien seePlayer;
    public float speed;
    Transform target;

    VungTanCong attack;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = transform.GetChild(0).GetComponent<VungPhatHien>();

        attack = transform.GetChild(1).GetComponent<VungTanCong>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        GoBack();
    }

    public void FollowPlayer()
    {
        if (seePlayer.see == true)
        {
            target = seePlayer.player;
            float x = target.position.x;
            

            if (attack.attack == true)
            {
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);
                anim.SetBool("hurt", false);
            }
            else
            {
                Vector2 temp = new Vector2(x, transform.position.y);
                transform.position = Vector2.Lerp(transform.position, temp, speed * Time.deltaTime);
                anim.SetBool("walk", true);
                anim.SetBool("attack", false);
                anim.SetBool("hurt", false);
            }

            if (x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    public void GoBack()
    {
        if (seePlayer.see == false)
        {
            target = transform.parent.transform;
            float x = target.position.x;
            Vector2 temp = new Vector2(x, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, temp, speed * Time.deltaTime);

            if (x != transform.position.x)
            {
                transform.position = Vector2.Lerp(transform.position, temp, speed * Time.deltaTime);
                anim.SetBool("walk", true);

                if (x > transform.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
            }
            else
            {
                anim.SetBool("walk", false);
            }
        }
    }

    public void AttackPlayer()
    {
        if (attack.attack == true)
        {

        }
    }
}
