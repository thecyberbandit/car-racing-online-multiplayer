using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;
using UnityEngine.UI;


public class DelayStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject delayStartButton; 
    [SerializeField]
    private GameObject delayCancelButton; 
    [SerializeField]
    private int roomSize;



    public override void OnConnectedToMaster() 
    {
        PhotonNetwork.AutomaticallySyncScene = true; 
        delayStartButton.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        //select an image for your own player 
    }

    public void DelayStart() 
    {
        delayStartButton.SetActive(false);
        delayCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); 
        Debug.Log("Delay Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom(); 
    }

    void CreateRoom()
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000); 
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps); 
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room! trying again...");
        CreateRoom(); 
    }

    public void DelayCancel() 
    {
        delayCancelButton.SetActive(false);
        delayStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
