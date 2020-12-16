using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviourPun {

    public GameObject localCamera;


    void Start()
    {
        {
            if (!photonView.IsMine)
            {
                localCamera.SetActive(false);

                MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();

                for (int i = 0; i < scripts.Length; i++)
                {
                    if (scripts[i] is NetworkPlayer)
                    {
                        continue;
                    }

                    else if (scripts[i] is PhotonView)
                    {
                        continue;
                    }

                    scripts[i].enabled = false;
                }
            }
        }
    }



}
