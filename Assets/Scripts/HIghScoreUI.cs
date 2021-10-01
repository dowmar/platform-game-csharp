using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HIghScoreUI : MonoBehaviour
{
    public Text HScore;

    public static HIghScoreUI high;

    

    void Start()
    {
        HScore.text = "Highscore : " + PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        PermanentUI.perm.ResetSkor();
        Debug.Log("Back to Menu");
        SceneManager.LoadScene("menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
    

