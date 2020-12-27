using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    [SerializeField] private Transform pervane;
    [SerializeField] private Transform arkaPervane;
    [SerializeField] private float speed;
    [SerializeField] private Animator latterAnimator;
    [SerializeField] private Collider colliderLatter;
    [SerializeField] private FollowTarget followTarget;
    private bool canActivateCollider;
    private float colliderTime=0;
    private float time = 0;
    private float positionHel = 0;
    private Vector3 startPos;
    private bool canMove=true;

    private void Start()
    {
        startPos = transform.position;
        followTarget = Camera.main.GetComponent<FollowTarget>();
    }


    void Update()
    {
        time += Time.deltaTime * speed;
        if (canMove)
        {
            positionHel = Mathf.Cos(Time.time * Mathf.PI);
            transform.position =startPos+ new Vector3(positionHel*2,0,0);
        }
        pervane.rotation = Quaternion.Euler(0,time,0);
        arkaPervane.rotation = Quaternion.Euler(0,0,time);
        if (canActivateCollider)
        {
            colliderTime += Time.deltaTime;
            if (colliderTime > 3.5f)
            {
                colliderLatter.enabled = true;
                canActivateCollider = false;
            }
        }
    }
    
    public void TriggerAnim()
    {
        latterAnimator.SetTrigger("canRelease");
        canActivateCollider = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.SetParent(this.transform);
            followTarget.canMove = false;
            GetComponent<PhotonView>().RPC("StopRpc",RpcTarget.All);
            other.transform.parent.parent.position = Vector3.zero;
        }
    }
    [PunRPC]
    private void StopRpc()
    {
        canMove = false;
    }
}
