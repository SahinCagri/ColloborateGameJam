using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
   private Transform target;
   public bool canMove = true;

   private void Update()
   {
      if (canMove && target != null)
      {
         transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime);
         //transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, 50 * Time.deltaTime);
      }
   }

   public void FollowPlayer(Transform _target)
   {
      this.target = _target;
      transform.position = _target.position;
      transform.rotation = _target.rotation;
      canMove = true;
   }
}
