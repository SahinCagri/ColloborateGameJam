using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float lookSensitivity = 3;
    [SerializeField] Rigidbody rb;
     Camera fpsCam;
     public Animator animator;
    [SerializeField] LayerMask groundMask;
    [SerializeField] LayerMask brickMask;
    [SerializeField] Collider collider;
    
     private Vector3 velocity = Vector3.zero;
     private Vector3 rotation = Vector3.zero;
     
     private bool canJump = true;
     private float cameraUpDown = 0;
     private float currentCameraUpDown = 0;
     public int PlayerNumber = 0;
     public Transform body;

     private void Start()
     {
         fpsCam = Camera.main;
     }

     private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 movementVelocity = (transform.right * xMovement + transform.forward * zMovement).normalized * speed;

        velocity = movementVelocity;
        if (velocity != Vector3.zero)
        {
            animator.SetInteger("Player",1);
        }
      else
        {
            animator.SetInteger("Player",2);
        }
        
        
        // shoot blocks
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
                if (hit.collider.tag == "Brick")
                {
                    hit.collider.gameObject.GetComponent<PhotonView>().RPC("PositionChange",RpcTarget.All,PlayerNumber);
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector3(0,7,0),ForceMode.Impulse);
            //animator.SetInteger("Player",3);
        }

    }

    private void FixedUpdate()
    {
        Move();
       
    }

    private void Move()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity*Time.fixedDeltaTime);
            body.rotation = Quaternion.LookRotation(velocity);
        }
    }
    
}
