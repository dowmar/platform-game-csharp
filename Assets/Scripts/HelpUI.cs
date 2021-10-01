using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpUI : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void backtomenu()
    {

        Debug.Log("Loading menu...");
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
        
    }


}
