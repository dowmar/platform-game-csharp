using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PermanentUI : MonoBehaviour
{
    //Carry over Stats
    public int cherry = 0;
    public TextMeshProUGUI CherryText;
    
    public int nyawa = 3;
    public TextMeshProUGUI jmlnyawa;

    public static PermanentUI perm;

    

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!perm)
        {
            perm = this; //current instance
        }
        else
           Destroy(gameObject);

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "theend")
        {
            Destroy(gameObject);
        }
        PlayerPrefs.SetInt("highscore", PermanentUI.perm.cherry);
    }
    public void ResetSkor()
    {
        cherry = 0;
        CherryText.text = cherry.ToString();
        nyawa = 3;

    }

}
