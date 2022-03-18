using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAndMana : MonoBehaviour
{
    [Header("Game characteristics")]
    public int hp = 10;
    public int mp = 10;


    void FixedUpdate()
    {
           if (mp <= 0)
           {
                mp = 0;
           }

            if (hp <= 0) {
            hp = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
