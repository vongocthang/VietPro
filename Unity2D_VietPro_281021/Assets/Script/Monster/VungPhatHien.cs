using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VungPhatHien : MonoBehaviour
{
    Demon demon;

    // Start is called before the first frame update
    void Start()
    {
        demon = transform.GetComponentInParent<Demon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Phat hien Player");
            demon.follow = true;
            demon.player = collision.gameObject;
        }
    }
}
