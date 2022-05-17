using UnityEngine;
using Photon.Pun;
public class CameraBehavior : MonoBehaviour
{

    PhotonView view;
    public Camera cam;
    public GameObject playerprefab;

    void start()
    {
        view = GetComponent<PhotonView>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        cam.transform.position =players[0].transform.position;
        print(players[0].transform.position);
    }
}