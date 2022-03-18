using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGuns : MonoBehaviour
{

    public Transform bullet;

    [Header("Submachine Guns settings")]

    [SerializeField] public int submachineGunsDamage = 3;
    [SerializeField] private float cast = 8f;
    [SerializeField] private float submachineGunsCooldown = 0.5f;


    private bool canUseSubmachineGuns = true;


    void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.LeftAlt))
            submachineGunsLaunching();
    }





    void submachineGunsLaunching()
    {
        if (canUseSubmachineGuns && gameObject.GetComponent<HealthAndMana>().mp > 0)
        {
            
            Transform clone = Instantiate(bullet, GameObject.Find("Submachine guns").transform.position,
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseSubmachineGuns = false;

            StartCoroutine(canUseSubmachineGunsCoroutine());

        }

    }

    IEnumerator canUseSubmachineGunsCoroutine()
    {

        yield return new WaitForSeconds(submachineGunsCooldown);

        canUseSubmachineGuns = true;

    }

}


