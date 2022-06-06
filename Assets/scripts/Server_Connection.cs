using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Server_Connection : MonoBehaviourPunCallbacks
{

    public InputField usernameInput;
    public Text buttonText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            //buttonText.text = "Connecting...";
            //PhotonNetwork.ConnectUsingSettings();
            SceneManager.LoadScene("Loading");
        }
    }

    

}