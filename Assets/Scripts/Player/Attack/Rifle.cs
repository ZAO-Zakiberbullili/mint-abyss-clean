using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{

    [SerializeField] private Transform bullet;

    [Header("Rifle settings")]

    [SerializeField] private int rifleDamage;
    [SerializeField] private float cast;
    [SerializeField] private float rifleCooldown;


    private bool canUseRifle = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
            rifleLaunching();

    }





    void rifleLaunching()
    {
        if (canUseRifle && gameObject.GetComponent<HealthAndMana>().GetMp() > 0)
        {

            Transform clone = Instantiate(bullet, GameObject.Find("Rifle").transform.position,
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseRifle = false;

            StartCoroutine(canUseRifleCoroutine());

        }

    }

    IEnumerator canUseRifleCoroutine()
    {

        yield return new WaitForSeconds(rifleCooldown);

        canUseRifle = true;

    }

    public int GetRifleDamage()
    {
        return this.rifleDamage;
    }
}


