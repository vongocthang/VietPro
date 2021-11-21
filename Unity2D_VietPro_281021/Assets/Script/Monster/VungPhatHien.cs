using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VungPhatHien : MonoBehaviour
{
    public bool see;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Phat hien Player");
            see = true;
            player = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Bo theo PLayer");
            see = false;
        }
    }
}
