using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerprefab;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private void Start()
    {
        
        Vector2 randomPosition = new Vector2(Random.Range(1,1), Random.Range(1,1));
        PhotonNetwork.Instantiate(playerprefab.name, randomPosition, Quaternion.identity);
    }
}
