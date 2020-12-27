using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManagerForCollaborate : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private Helicopter helicopter;
    private void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Instantiate(playerPrefab.name,spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber % 2].position,spawnPositions[PhotonNetwork.LocalPlayer.ActorNumber % 2].rotation);
        }
    }

    public override void OnJoinedRoom()
    {
        print(PhotonNetwork.NickName+"  katıldı" + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print(newPlayer.NickName+" " + PhotonNetwork.CurrentRoom.Name);
    }

    public void GoBackToMenu()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            helicopter.TriggerAnim();
        }
    }
}
