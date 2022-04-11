using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    [SerializeField] private Transform fireball;

    [Header("Fireball settings")]

    [SerializeField] private int fireballDamage;
    [SerializeField] private float cast;
    [SerializeField] private float fireballCooldown;
    [SerializeField] private int manaCost;

    [Header("Burning settings")]
    [SerializeField] private int burningTime;
    [SerializeField] private int strokesNumbers;
    [SerializeField] private int burningDamage;


    private bool canUseFireball = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
            fireballLaunching();
    }



   

    void fireballLaunching() {
        if (canUseFireball && gameObject.GetComponent<HealthAndMana>().GetMp() > manaCost)
        {

            Transform clone = Instantiate(fireball, transform.position + (transform.rotation.y < 0 ? new Vector3(-0.375f, 0f, 0f) : new Vector3(0.375f, 0f, 0f)),
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));
           
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseFireball = false;


            gameObject.GetComponent<HealthAndMana>().SpendMP(manaCost);

            StartCoroutine(canUseFireballCoroutine());

            print("Mana" + gameObject.GetComponent<HealthAndMana>().GetMp());
            
        }
        
    }

    IEnumerator canUseFireballCoroutine()
    {

        yield return new WaitForSeconds(fireballCooldown);

        canUseFireball = true;
        
    }


    public int GetFireballDamage()
    {
        return this.fireballDamage;
    }
    public int GetBurningTime() { 
        return this.burningTime;
    }
    public int GetStrokesNumbers() {
        return this.strokesNumbers;
    }
    public int GetBurningDamage()
    {
        return this.burningDamage;
    }
}


