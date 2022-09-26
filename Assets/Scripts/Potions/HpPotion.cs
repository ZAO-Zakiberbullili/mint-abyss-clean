using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPotion : MonoBehaviour
{
    [SerializeField] protected int restoreHp;

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<HealthAndMana>().RestoreHp(restoreHp);
            Destroy(gameObject);
        }

    }
}
