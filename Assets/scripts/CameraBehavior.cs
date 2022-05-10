using UnityEngine;
using Photon.Pun;
public class CameraBehavior : MonoBehaviour
{

    PhotonView view;

    void start()
    {
        view = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}