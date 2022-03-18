using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    [HideInInspector] public bool isStun;
    [HideInInspector] public bool isBurn;


    private bool isStunCoroutineAlreadyStart = false;
    private bool isBurnCoroutineAlreadyStart = false;


    
    private void Awake()
    {
        isStun = false;
        isBurn = false;
    }
    void FixedUpdate()
    {
        if (isStun && !isStunCoroutineAlreadyStart)
        {
            isStunCoroutineAlreadyStart = true;
            StartCoroutine(isStunCoroutine());
        }

        if (isBurn && !isBurnCoroutineAlreadyStart)
        {
            isBurnCoroutineAlreadyStart = true;
            StartCoroutine(isBurnCoroutine());
        }
    }

    public void getDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }

    public IEnumerator isStunCoroutine()
    {
        yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<AirSphere>().stunTime);

        isStun = false;
        isStunCoroutineAlreadyStart = false;
        yield break;

    }

    public IEnumerator isBurnCoroutine()
    {


        for (int i = 0; i < GameObject.Find("Player").GetComponent<Fireball>().strokesNumbers; i++)
        {
            print("BUUUURN");
            getDamage(GameObject.Find("Player").GetComponent<Fireball>().burningDamage);
            yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<Fireball>().burningTime / 
                GameObject.Find("Player").GetComponent<Fireball>().strokesNumbers);

        }

        isBurn = false;
        isBurnCoroutineAlreadyStart = false;
        yield break;

    }


}
