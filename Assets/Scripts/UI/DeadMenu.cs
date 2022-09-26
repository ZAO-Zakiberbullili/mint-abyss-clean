using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    [SerializeField] private int deadMenuStartTime;
    [SerializeField] private GameObject gotoMenu;
    [SerializeField] private GameObject reloadScene;
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private GameObject deadTextImg;
    [SerializeField] private GameObject deadMenu;

    private void Awake()
    {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }


    public  void DeadScreen()
    {
        Time.timeScale = 0f;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        deadMenu.SetActive(true);
        StartCoroutine(DeadScreenVisibleCoroutine());
    }

    IEnumerator DeadScreenVisibleCoroutine()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(deadMenuStartTime / 100);
            reloadScene.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            gotoMenu.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
            deadScreen.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0.01f);
            deadTextImg.GetComponent<Image>().color += new Color(0, 0, 0, 0.01f);
        }
 }


    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
