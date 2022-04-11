using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Image hpBar;
    [SerializeField] private Image mpBar;
    [SerializeField] private Image hpBarBackGround;

    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            MenuPause();
    }
    public void MenuPause()
    {
        if (!isPaused)
        {
            hpBar.CrossFadeAlpha(0, 0, false);
            mpBar.CrossFadeAlpha(0, 0, false);
            hpBarBackGround.CrossFadeAlpha(0, 0, false);

            Time.timeScale = 0f;
            isPaused = true;

            pauseMenu.SetActive(true);
        }
        else
        {
            hpBar.CrossFadeAlpha(1f, 0, false);
            mpBar.CrossFadeAlpha(1f, 0, false);
            hpBarBackGround.CrossFadeAlpha(1f, 0, false);

            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
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
