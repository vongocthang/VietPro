using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public bool follow;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FollowPlayer()
    {
        if (follow == true)
        {
            float x = player.transform.position.x;
            Vector2 temp = new Vector2(x, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, temp, 
                10 * Time.deltaTime);
        }
    }
}
