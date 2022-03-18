using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Enemy")
        {
            collider.GetComponent<Health>().getDamage(GameObject.Find("Player").GetComponent<Fireball>().fireballDamage);
            collider.GetComponent<Health>().isBurn = true;
          
            Destroy(gameObject);
        }

    }


    
}
