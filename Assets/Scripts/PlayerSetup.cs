using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    [SerializeField] private MovementController movementController;
    //[SerializeField] private GameObject camera;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private TextMeshProUGUI playerName;
    private void Start()
    {
        if (photonView.IsMine)
        {
            movementController.enabled = true;
            //camera.SetActive(true);
            Camera.main.GetComponent<FollowTarget>().FollowPlayer(cameraPos);
            playerName.gameObject.SetActive(false);
            GetComponent<MovementController>().PlayerNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        }
        else
        {
            movementController.enabled = false;
            //camera.SetActive(false);
        }
        playerName.text = photonView.Owner.NickName;

        

    }
}
