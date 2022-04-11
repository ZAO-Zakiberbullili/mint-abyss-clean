using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int hp;
    [HideInInspector] private bool isStun;
    [HideInInspector] private bool isBurn;


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
        yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<AirSphere>().GetStunTime());

        isStun = false;
        isStunCoroutineAlreadyStart = false;
        yield break;

    }

    public IEnumerator isBurnCoroutine()
    {


        for (int i = 0; i < GameObject.Find("Player").GetComponent<Fireball>().GetStrokesNumbers(); i++)
        {
            print("BUUUURN");
            getDamage(GameObject.Find("Player").GetComponent<Fireball>().GetBurningDamage());
            yield return new WaitForSeconds(GameObject.Find("Player").GetComponent<Fireball>().GetBurningTime() / 
                GameObject.Find("Player").GetComponent<Fireball>().GetStrokesNumbers());

        }

        isBurn = false;
        isBurnCoroutineAlreadyStart = false;
        yield break;

    }

    public bool GetIsStun()
    {
        return this.isStun;
    }
    public bool GetIsBurn()
    {
        return this.isBurn;
    }

    public void SetIsStun(bool isStun)
    {
       this.isStun = isStun;
    }
    public void SetIsBurn(bool isBurn)
    {
        this.isBurn = isBurn;
    }

}
