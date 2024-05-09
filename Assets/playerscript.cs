using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;
        float moveSpeed = 1;
        float moveSpeed2 = -1;
        float jump = 5;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = moveSpeed2;
        }
        else
        {
            v.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            v.y = jump;
        }
        rb.velocity = v;

      

    }
}
