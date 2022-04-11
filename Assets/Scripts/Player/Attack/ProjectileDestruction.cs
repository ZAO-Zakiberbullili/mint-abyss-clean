using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestruction : MonoBehaviour
{
    [SerializeField] private float seconds;

    [SerializeField] private float damage;

    void Start()
    {
        Destroy(gameObject, seconds);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
