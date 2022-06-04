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
    //public Text username;
    private void Start()
    {




        Vector2 randomPosition = new Vector2(1, -6);
        if (PhotonNetwork.IsMasterClient)
        {
            
            for (int i = 1; i < 30; i++)
            {
                int Pos_x = Random.Range(-10, 10);
                PhotonNetwork.Instantiate(Terrarian.name, new Vector2(Pos_x, randomPosition.y + 4 * i), Quaternion.identity);
            }
        }
        GameObject Player=PhotonNetwork.Instantiate(playerprefab.name, randomPosition, Quaternion.identity);
      
        


    }
}
