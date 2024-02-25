using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    
    [SerializeField] TMP_Text TMP_Timer;
    [SerializeField] GameObject spawner;


    float elapsedTime;

    void Start()
    {
        TMP_Timer.text = "0:00";

        PlayerPrefs.SetInt("minutes", 0);
        PlayerPrefs.SetInt("seconds", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        TMP_Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        PlayerPrefs.SetInt("minutes", minutes);
        PlayerPrefs.SetInt("seconds", seconds);
        
    }
}
