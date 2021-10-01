using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string scenename;

    public GameObject Helpui;
    public GameObject menuone;

    void Start()
    {
        if (PermanentUI.perm) Destroy(PermanentUI.perm.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Startgame()
    {

        Debug.Log("Loading menu...");
        SceneManager.LoadScene(scenename);
    }

    //TODO
    public void help()
    {
        Debug.Log("Instructions....");
        Helpui.SetActive(true);
        menuone.SetActive(false);
        
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
