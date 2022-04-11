using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject submachineGuns;
    [SerializeField] GameObject rifle;

    enum WeaponList
    {
        SubmachineGun,
        Rifle
    }

    private WeaponList weaponList = WeaponList.SubmachineGun;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            
            if (weaponList != WeaponList.SubmachineGun)
            {
                weaponList = WeaponList.SubmachineGun;

                submachineGuns.SetActive(true);
                GetComponent<Rifle>().enabled = false;
                GetComponent<SubmachineGuns>().enabled = true;
                rifle.SetActive(false);
            }

        }
            
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            if (weaponList != WeaponList.Rifle)
            {
                weaponList = WeaponList.Rifle;

                rifle.SetActive(true);
                GetComponent<SubmachineGuns>().enabled = false;
                GetComponent<Rifle>().enabled = true;
                submachineGuns.SetActive(false);

                
            }
        }
    }

  
}
