using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject [] Players;
    public GameObject Terrarian;
    public GameObject Camera;
    //public GameObject FirePoint;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    public static int height = 1;
    private int currentBomb;
    public GameObject Countdown;
    public static GameObject[] Bombs;
    Vector2 randomPosition = new Vector2(1, -6);

    private void Start()
    {



        GameObject Player= Players[(int) (PhotonNetwork.LocalPlayer.CustomProperties["playerAvatar"])];


        if (PhotonNetwork.IsMasterClient)
        {
            
            for (; height < 30; height++)
            {
                int Pos_x = Random.Range(-10, 10);
                PhotonNetwork.Instantiate(Terrarian.name, new Vector2(Pos_x, randomPosition.y + 4 * height), Quaternion.identity);
            }
        }

        print(PhotonNetwork.CurrentRoom.PlayerCount);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            randomPosition = new Vector2(3, -6);
            //PhotonNetwork.Instantiate(Countdown.name, new Vector2(3, 3), Quaternion.identity);


        }

        else if (PhotonNetwork.CurrentRoom.PlayerCount == 3)
        {
            randomPosition = new Vector2(4, -6);


        }

       else if (PhotonNetwork.CurrentRoom.PlayerCount == 4)
        {
            randomPosition = new Vector2(5, -6);


        }

          Player = PhotonNetwork.Instantiate(Player.name, randomPosition, Quaternion.identity);
       
       



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
