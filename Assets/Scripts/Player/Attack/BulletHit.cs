using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().getDamage(GameObject.Find("Player").GetComponent<SubmachineGuns>().submachineGunsDamage);
            Destroy(gameObject);
        }

    }
}