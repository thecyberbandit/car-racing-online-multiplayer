using Photon.Pun;
using System.IO;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class GameSetupController : MonoBehaviourPunCallbacks {

    public static GameSetupController instance;

    public Transform[] spawnPoints;

    public string playerPrefabNameMaster = "Player1";
    public string playerPrefabNameClient = "Player2";

    public Sprite[] playerImages;

    private GameObject player;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    
    void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        Debug.Log("Creating Player");

        if (PhotonNetwork.IsMasterClient)
        {
            player = PhotonNetwork.Instantiate(playerPrefabNameMaster, GameSetupController.instance.spawnPoints[0].position,
                                                          GameSetupController.instance.spawnPoints[0].rotation, 0);
        }

        else
        {
            player = PhotonNetwork.Instantiate(playerPrefabNameClient, GameSetupController.instance.spawnPoints[1].position,
                                                          GameSetupController.instance.spawnPoints[1].rotation, 0);
        }
    }

    public void Disconnect()
    {
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.LeaveRoom();

        while (PhotonNetwork.InRoom)
        {
            yield return null;
        }

        SceneManager.LoadScene(0);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SceneManager.LoadScene(3);
    }
}
