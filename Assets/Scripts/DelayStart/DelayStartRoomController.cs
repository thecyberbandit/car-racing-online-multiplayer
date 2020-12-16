using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Realtime;


public class DelayStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int waitingRoomSceneIndex;
    private ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();



    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom() 
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PlayerPrefs.SetString("MasterName", "Master");
            PlayerPrefs.SetInt("MasterImage", 0);
        }

        else
        {
            PlayerPrefs.SetString("ClientName", "Client");
            PlayerPrefs.SetInt("ClientImage", 1);
        }

        int i = Random.Range(1, 100);
        
        SceneManager.LoadScene(waitingRoomSceneIndex);
    }
}
