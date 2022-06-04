using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_To_Join : MonoBehaviour
{
    public float targetTime = 30.0f;
    public GameObject count;

    void Start()
    {
        count.SetActive(true);
        count.GetComponentInChildren<Text>().text = "Waiting for more players to Join";
        Time.timeScale = 0.001f;
        
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length >= 2)
        {
            count.GetComponentInChildren<Text>().text = "Time until game starts: " + targetTime.ToString();
            targetTime -= Time.deltaTime * 1000;
            print(count.GetComponentInChildren<Text>().text);


            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }
    }

    void timerEnded()
    {
        count.SetActive(false);
        Time.timeScale = 1;
    }


}

