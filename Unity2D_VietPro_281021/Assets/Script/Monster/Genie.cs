using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Genie : MonoBehaviour
{
    VungPhatHien seePlayer;
    AIDestinationSetter aiSetter;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = transform.GetChild(0).GetComponent<VungPhatHien>();
        aiSetter = GetComponent<AIDestinationSetter>();
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
            aiSetter.target = target;

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
            aiSetter.target = target;

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
}
