using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AirSphere : MonoBehaviour
{

    public Transform Airsphere;

    [Header("AirSphere settings")]

    [SerializeField] public int airSphereDamage = 3;
    [SerializeField] private float cast = 8f;
    [SerializeField] private float airSphereCooldown = 4f;
    [SerializeField] private int manaCost = 4;

    [Header("Stun settings")]
    public int stunTime = 4;


    private bool canUseAirSphere = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
            airSphereLaunching();
    }





    void airSphereLaunching()
    {
        if (canUseAirSphere && gameObject.GetComponent<HealthAndMana>().mp > 0)
        {

            Transform clone = Instantiate(Airsphere, transform.position + (transform.rotation.y < 0 ? new Vector3(-0.375f, 0f, 0f) : new Vector3(0.375f, 0f, 0f)),
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));

            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseAirSphere = false;


            gameObject.GetComponent<HealthAndMana>().mp -= manaCost;

            StartCoroutine(canUseAirSphereCoroutine());

            print("Mana" + gameObject.GetComponent<HealthAndMana>().mp);

        }

    }

    IEnumerator canUseAirSphereCoroutine()
    {

        yield return new WaitForSeconds(airSphereCooldown);

        canUseAirSphere = true;

    }

}


