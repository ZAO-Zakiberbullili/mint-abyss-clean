using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthAndMana : MonoBehaviour
{
    [Header("Game characteristics")]
    [SerializeField] private int hp;
    [SerializeField] private int maxHp;
    [SerializeField] private int mp;
    [SerializeField] private int maxMp;
    [SerializeField] private int manaRecoveredPerSecond;
    [SerializeField] private int delayBeforeManaRecovery;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image mpBar;
    [SerializeField] private Image hpBarBackGround;

   public void SpendMP(int mp)
   {
        StopCoroutine("DelayBeforeManaRecoveryCoroutine");
        
        this.mp -= mp;

        updateMpUI();
        
        if (this.mp <= 0)
        {
            this.mp = 0;
        }
        StartCoroutine("DelayBeforeManaRecoveryCoroutine");
    }

    public void RestoreHp(int hp)
    {
        this.hp += hp;
        if (this.hp > this.maxHp)
        {
            this.hp = this.maxHp;
        }

        updateHpUI();
    }

    IEnumerator DelayBeforeManaRecoveryCoroutine() 
    {
        yield return new WaitForSeconds(delayBeforeManaRecovery);

        while(true)
        {
            this.mp += manaRecoveredPerSecond;
            yield return new WaitForSeconds(1);

            updateMpUI();

            if (this.mp >= this.maxMp)
            {
                this.mp = this.maxMp;
                yield break;
            }
 
        }
    }

    public void GetDamage(int damage)
    {
        hp -= damage;

        updateHpUI();
        
        if (hp <= 0) {
            hp = 0;
            GameObject.Find("Canvas").GetComponent<DeadMenu>().DeadScreen();
            hpBar.CrossFadeAlpha(0, 0, false);
            hpBarBackGround.CrossFadeAlpha(0, 0, false);
            mpBar.CrossFadeAlpha(0, 0, false);
        }
    }

    public void Awake()
    {
        hpBar.CrossFadeAlpha(1f, 0, false);
        hpBarBackGround.CrossFadeAlpha(1f,0,false);
        mpBar.CrossFadeAlpha(1f, 0, false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            GetDamage(1);
    }

    public int GetMp()
    {
        return this.mp;
    }

    public int GetHp()
    {
        return this.hp;
    }

    void updateHpUI()
    {
        hpBar.fillAmount = (float)(this.hp) / this.maxHp;
    }

    void updateMpUI()
    {
        mpBar.fillAmount = (float)(this.mp) / this.maxMp;
    }
}
