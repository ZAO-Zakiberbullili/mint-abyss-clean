using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AirSphere : MonoBehaviour
{

    [SerializeField] private Transform Airsphere;

    [Header("AirSphere settings")]

    [SerializeField] private int airSphereDamage;
    [SerializeField] private float cast;
    [SerializeField] private float airSphereCooldown;
    [SerializeField] private int manaCost;

    [Header("Stun settings")]
    [SerializeField] private int stunTime;


    private bool canUseAirSphere = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
            airSphereLaunching();
    }





    void airSphereLaunching()
    {
        if (canUseAirSphere && gameObject.GetComponent<HealthAndMana>().GetMp() > manaCost)
        {

            Transform clone = Instantiate(Airsphere, transform.position + (transform.rotation.y < 0 ? new Vector3(-0.375f, 0f, 0f) : new Vector3(0.375f, 0f, 0f)),
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));

            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseAirSphere = false;


            gameObject.GetComponent<HealthAndMana>().SpendMP(manaCost);

            StartCoroutine(canUseAirSphereCoroutine());

            print("Mana" + gameObject.GetComponent<HealthAndMana>().GetMp());

        }

    }

    IEnumerator canUseAirSphereCoroutine()
    {

        yield return new WaitForSeconds(airSphereCooldown);

        canUseAirSphere = true;

    }

    public int GetAirSphereDamage() {
        return this.airSphereDamage;
    }
    public int GetStunTime()
    {
        return this.stunTime;
    }
}


