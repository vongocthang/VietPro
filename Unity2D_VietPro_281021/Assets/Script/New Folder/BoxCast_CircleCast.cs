using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast_CircleCast : MonoBehaviour
{
    [SerializeField]
    LayerMask CheckVaCham;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(10f, 10f), 0f,
            Vector2.right, 5f, CheckVaCham);
        //RaycastHit2D hit = Physics2D.CircleCast(transform.position, 5f, Vector2.right, 5f, CheckVaCham);

        if (hit)
        {
            Debug.Log("Va cham voi: " + hit.transform.gameObject.name);
        }
    }
}
