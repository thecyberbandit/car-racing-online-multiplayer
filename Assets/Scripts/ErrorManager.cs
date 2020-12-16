using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ErrorManager : MonoBehaviour {


    IEnumerator DisconnectAndLoad()
    {
        //PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveRoom();

        //while (PhotonNetwork.IsConnected)
        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }
    }

    public void Menu()
    {
        StartCoroutine(DisconnectAndLoad());

        SceneManager.LoadScene(0);
    }

}
