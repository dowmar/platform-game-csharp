using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class timerCountdown : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public float sisaDetik = 30f;
    public static bool jalanDetik = false;

    void Start()
    {
        
        StartCoroutine(TimerStart());
        
        timerDisplay.GetComponent<TextMeshProUGUI>().text = "" + sisaDetik;

    }

    // Update is called once per frame
    void Update()
    {
        if (jalanDetik == false && sisaDetik > 0)
        {
            StartCoroutine(TimerStart());
        }

       if (jalanDetik == false && sisaDetik <= 0)
       {
            //Debug.Log("jalan");
            gameend();
       }
    }

    IEnumerator TimerStart()
    {
       
        jalanDetik = true;
        yield return new WaitForSeconds(1);
        sisaDetik -= 1f;
        if (sisaDetik < 10f)
        {
            timerDisplay.GetComponent<TextMeshProUGUI>().text = "0" + sisaDetik;
        }
        
        else 
        {
            timerDisplay.GetComponent<TextMeshProUGUI>().text = "" + sisaDetik;
        }
        
        jalanDetik = false;
        

    }

    void gameend()
    {
        SceneManager.LoadScene("theend");
    }
}
