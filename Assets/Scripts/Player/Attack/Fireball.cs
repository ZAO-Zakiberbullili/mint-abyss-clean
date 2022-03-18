using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public Transform fireball;

    [Header("Fireball settings")]

    [SerializeField] public int fireballDamage = 3;
    [SerializeField] private float cast = 8f;
    [SerializeField] private float fireballCooldown = 4f;
    [SerializeField] private int manaCost = 4;

    [Header("Burning settings")]
    public int burningTime = 2;
    public int strokesNumbers = 2;
    public int burningDamage = 2;


    private bool canUseFireball = true;


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
            fireballLaunching();
    }



   

    void fireballLaunching() {
        if (canUseFireball && gameObject.GetComponent<HealthAndMana>().mp > 0)
        {

            Transform clone = Instantiate(fireball, transform.position + (transform.rotation.y < 0 ? new Vector3(-0.375f, 0f, 0f) : new Vector3(0.375f, 0f, 0f)),
                   transform.rotation.y < 0 ? new Quaternion(0f, -180f, 0f, 0f) : new Quaternion(0f, 0f, 0f, 0f));
           
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * cast);

            canUseFireball = false;

            
            gameObject.GetComponent<HealthAndMana>().mp -= manaCost;

            StartCoroutine(canUseFireballCoroutine());

            print("Mana" + gameObject.GetComponent<HealthAndMana>().mp);
            
        }
        
    }

    IEnumerator canUseFireballCoroutine()
    {

        yield return new WaitForSeconds(fireballCooldown);

        canUseFireball = true;
        
    }

}


