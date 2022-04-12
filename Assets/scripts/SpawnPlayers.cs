using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerprefab;
<<<<<<< Updated upstream
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
=======
   // public float minX;
    //public float minY;
    //public float maxX;
    //public float maxY;
>>>>>>> Stashed changes

    private void Start()
    {
        
<<<<<<< Updated upstream
        Vector2 randomPosition = new Vector2(Random.Range(1,1), Random.Range(1,1));
=======
        Vector2 randomPosition = new Vector2(1, 1);
>>>>>>> Stashed changes
        PhotonNetwork.Instantiate(playerprefab.name, randomPosition, Quaternion.identity);
    }
}
