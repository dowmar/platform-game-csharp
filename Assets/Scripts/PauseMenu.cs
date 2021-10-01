using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private string scenename;
    public static bool GamePaused = false;

    public GameObject PauseMenuUI;

    public static PauseMenu pausing;

    private void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

    }    


    //TODO
    public void LoadMenu()
    {
        SceneManager.LoadScene(scenename);
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        
    }

    
}
