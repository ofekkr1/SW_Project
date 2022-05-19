using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Back : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
            SceneManager.LoadScene(sceneName: "SampleScene");
        }
    }
}
