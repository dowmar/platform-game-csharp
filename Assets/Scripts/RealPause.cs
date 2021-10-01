using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealPause : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] GameObject pausoMenu;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Lanjut();
            }
            else
            {
                Pausedo();
            }
        }
    }

    public void Lanjut()
    {
        pausoMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void Pausedo()
    {
        pausoMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void loadingmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitto()
    {
        Application.Quit();
    }
}
