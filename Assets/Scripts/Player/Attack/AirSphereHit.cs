using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSphereHit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().getDamage(GameObject.Find("Player").GetComponent<AirSphere>().airSphereDamage);
            collider.GetComponent<Health>().isStun = true;

            Destroy(gameObject);
        }

    }



}
