using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerprefab;
    public GameObject Terrarian;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    private void Start()
    {


       
        
        Vector2 randomPosition = new Vector2(1, -6);
        for (int i = 1; i < 30; i++)
        {
            int Pos_x = Random.Range(-10, 10);
            PhotonNetwork.Instantiate(Terrarian.name, new Vector2(Pos_x, randomPosition.y + 4*i), Quaternion.identity);
        }
        PhotonNetwork.Instantiate(playerprefab.name, randomPosition, Quaternion.identity);
        
    }
}
