using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_To_Join : MonoBehaviour
{
    

    bool startTimer = false;
    double timerIncrementValue;
    double startTime;
    [SerializeField] double timer = 20;
    ExitGames.Client.Photon.Hashtable CustomeValue;
    public GameObject text;

    public static bool GameStarted = false;

    void Start()
    {
                    //    CustomeValue = new ExitGames.Client.Photon.Hashtable();
            //    startTime = PhotonNetwork.Time;
            //    startTimer = true;
            //    CustomeValue.Add("StartTime", startTime);
            //    PhotonNetwork.CurrentRoom.SetCustomProperties(CustomeValue);
            //}
            //else
            //{
            //    startTime = double.Parse(PhotonNetwork.CurrentRoom.CustomProperties["StartTime"].ToString());
            //    startTimer = true;
            //}
            GameStarted = true;
    }

    void Update()
    {

        //if (!startTimer) return;

        //timerIncrementValue = PhotonNetwork.Time - startTime;
        //text.GetComponentInChildren<Text>().text ="Time until the game starts: " + ((int)(timer-timerIncrementValue)).ToString();

        //foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        //{
        //    player.GetComponent<Rigidbody2D>().isKinematic = true;
        //}

        //if (timerIncrementValue >= timer)
        //{
        //    foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        //    {
        //        player.GetComponent<Rigidbody2D>().isKinematic = false;
        //    }
           
        //    text.gameObject.SetActive(false);
        //}
    }
}

