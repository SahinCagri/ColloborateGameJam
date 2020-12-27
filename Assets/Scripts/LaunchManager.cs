using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = UnityEngine.Random;


public class LaunchManager : MonoBehaviourPunCallbacks
{
    public GameObject enterGamePanel;
    public GameObject conneectionStatusPanel;
    public GameObject lobbyPanel;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Start()
    {
        enterGamePanel.SetActive(true);
        conneectionStatusPanel.SetActive(false);
        if (PhotonNetwork.IsConnected)
        {
            enterGamePanel.SetActive(false);
            conneectionStatusPanel.SetActive(true);
        }
    }

    public void ConnectToPhotonServer()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
            enterGamePanel.SetActive(false);
            conneectionStatusPanel.SetActive(true);
        }
       
       
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnConnectedToMaster()
    {
        print(PhotonNetwork.NickName+" Connecttred to photon");
        lobbyPanel.SetActive(true);
        conneectionStatusPanel.SetActive(false);
    }

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.CurrentRoom.Name);
        print(PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    public void CreateRoom()
    {
        string randomname = "Oda" + Random.Range(0, 55);
        RoomOptions options = new RoomOptions();
        options.IsVisible = true;
        options.IsOpen = true;
        options.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(randomname,options);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName + " katıldı");
    }
}
