using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmachineGuns : MonoBehaviour
{

    [SerializeField] private Transform bullet;

    [Header("Submachine Guns settings")]

    [SerializeField] private int submachineGunsDamage;
    [SerializeField] private float cast;
    [SerializeField] private float submachineGunsCooldown;


    private bool canUseSubmachineGuns = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
            submachineGunsLaunching();
        
    }





    void submachineGunsLaunching()
    {
        if (canUseSubmachineGuns && gameObject.GetComponent<HealthAndMana>().GetMp() > 0)
        {
            
            Transform clone = Instantiate(bullet, GameObject.Find("SubmachineGuns").transform.position,
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

    public int GetSubmachineGunsDamage() {
        return this.submachineGunsDamage;
    }
}


