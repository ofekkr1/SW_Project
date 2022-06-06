using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;

 
    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;

    //public List<PlayerItem> playerItemList = new List<PlayerItem>();
    //public PlayerItem playerItemPrefab;
    //public Transform playerItemParent;




    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void OnClickCreate()
    {
        if (roomInputField.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 4, BroadcastPropsChangeToAll = true });
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        //UpdatePlayerList();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomlist)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomlist);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    private void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    //void UpdatePlayerList()
    //{
    //    foreach (PlayerItem item in playerItemList)
    //    {
    //        Destroy(item.gameObject);
    //    }
    //    playerItemList.Clear();
    //    if (PhotonNetwork.CurrentRoom == null)
    //        return;

    //    foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
    //    {
    //        PlayerItem newplayer = Instantiate(playerItemPrefab, playerItemParent);
    //        newplayer.SetPlayerInfo(player.Value);

    //        if (player.Value == PhotonNetwork.LocalPlayer)
    //            newplayer.ApplyLocalChanges();

    //        playerItemList.Add(newplayer);
    //    }

    //}

    //public override void OnPlayerEnteredRoom(Player newPlayer)
    //{
    //    UpdatePlayerList();
    //}

    //public override void OnPlayerLeftRoom(Player otherPlayer)
    //{
    //    UpdatePlayerList();
    //}
}
