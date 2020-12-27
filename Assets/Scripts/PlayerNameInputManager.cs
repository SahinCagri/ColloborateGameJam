using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerNameInputManager : MonoBehaviour
{
   public void SetPlayername(string playername)
   {
      if (string.IsNullOrEmpty(playername))
      {
         print("isim gir");
         return;
      }

      PhotonNetwork.NickName = playername;
   }
}
