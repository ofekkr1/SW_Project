using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerprefab;
    public GameObject Terrarian;
    public GameObject Camera;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public static int height = 1;
    public GameObject Countdown;
    Vector2 randomPosition = new Vector2(1, -6);

    private void Start()
    {




       
        if (PhotonNetwork.IsMasterClient)
        {
            
            for (; height < 30; height++)
            {
                int Pos_x = Random.Range(-10, 10);
                PhotonNetwork.Instantiate(Terrarian.name, new Vector2(Pos_x, randomPosition.y + 4 * height), Quaternion.identity);
            }
        }
        if (GameObject.FindGameObjectsWithTag("Player").Length==1)
        {
            randomPosition = new Vector2(3, -9);
            PhotonNetwork.Instantiate(Countdown.name, new Vector2(3, 3), Quaternion.identity);
            
        }
        
        GameObject Player = PhotonNetwork.Instantiate(playerprefab.name, randomPosition, Quaternion.identity);
        



    }


    void Update()
    {
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        GameObject firstToCome = HeighestPlayer(Players);
        if(GameObject.FindGameObjectsWithTag("Platform").Length==4)
        {
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        for (; height < height+30; height++)
        {
            int Pos_x = Random.Range(-10, 10);
            PhotonNetwork.Instantiate(Terrarian.name, new Vector2(Pos_x, randomPosition.y + 4 * height), Quaternion.identity);
        }
    }

    private GameObject HeighestPlayer(GameObject[] Players)
    {

        if (Players.Length > 0)
        {
            foreach (GameObject player1 in Players)
            {
                bool highest = true;
                foreach (GameObject player2 in Players)
                {
                    if (player1.transform.position.y < player2.transform.position.y)
                    {
                        highest = false;
                        break;
                    }
                }
                if (highest) return player1;
            }
            return Players[Players.Length - 1];
        }
        return null;
    }
}
