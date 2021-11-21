using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genie2 : MonoBehaviour
{
    VungPhatHien seePlayer;
    NavMeshAgent2D ai;
    Transform target;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = transform.GetChild(0).GetComponent<VungPhatHien>();
        ai = GetComponent<NavMeshAgent2D>();

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
            ai.destination = target.position;

            if (target.position.x > transform.position.x)
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
            ai.destination = target.position;

            if (target.position.x > transform.position.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }
}
