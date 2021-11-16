using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2D : MonoBehaviour
{
    public bool moveLeft, moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newVector2Right = new Vector2(transform.position.x + 3, transform.position.y);
        Vector2 newVector2Left = new Vector2(transform.position.x - 3, transform.position.y);

        if (moveRight == true)
        {
            RaycastHit2D hitRight = Physics2D.Raycast(newVector2Right, Vector2.right, 1f);
            Debug.DrawRay(newVector2Right, Vector2.right * 1f, Color.green);
            if (hitRight.collider != null)
            {
                moveRight = false;
                moveLeft = true;
            }
        }
        if (moveLeft == true)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(newVector2Left, Vector2.left, 1f);
            Debug.DrawRay(newVector2Left, Vector2.left * 1f, Color.green);
            if (hitLeft.collider != null)
            {
                moveRight = true;
                moveLeft = false;
            }
        }
        
        if (moveRight == true)
        {
            transform.Translate(Vector2.right * 2 * Time.deltaTime);
        }
        if (moveLeft == true)
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        }
    }
}
