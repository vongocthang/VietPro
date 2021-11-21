using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VungTanCong : MonoBehaviour
{
    public bool attack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack = false;
        }
    }
}
