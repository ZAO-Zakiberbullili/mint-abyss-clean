using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementaryMove : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (!gameObject.GetComponent<Health>().GetIsStun())
        {
            rb.velocity = new Vector2 (5f,-9.8f);
        }
        else {
            rb.velocity = new Vector2(0f, -9.8f);
        }
    }
}
