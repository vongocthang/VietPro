using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Va chạm cứng với Thùng hóa chất");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Kết thúc va chạm cứng với Thùng hóa chất");
        }
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
