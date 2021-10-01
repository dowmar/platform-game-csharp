using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPause : MonoBehaviour
{
    public static bool Gamehaus = false;

    public GameObject newPause;

    void Start()
    {
        newPause.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gamehaus)
            {
                Resuman();
            }
            else
            {
                testw();
            }
        }
    }

    public void Resuman()
    {

        newPause.SetActive(false);
        Time.timeScale = 1f;
        Gamehaus = false;
    }
    public void testw()
    {
        newPause.SetActive(true);
        Time.timeScale = 0f;
        Gamehaus = true;
    }
    public void unPause()
    {

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        Gamehaus = false;
    }

    public void shiftMenu()
    {
        
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
        Gamehaus = false;
    }

}
