using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviourPun {

    public int localScore = 0;
    public int remoteScore = 0;

    public Text localScoreText;
    public Text remoteScoreText;

    private PhotonView PV;



    void Start()
    {
        PV = GetComponent<PhotonView>();
        UpdateLocalText();
        UpdateRemoteText();
    }

    public void OnScoreButtonPressed()
    {
        localScore++;
        UpdateLocalText();

        PV.RPC("RPC_AddScore", RpcTarget.Others);
    }

    [PunRPC]
    void RPC_AddScore()
    {
        remoteScore++;
        UpdateRemoteText();
    }

    public void UpdateLocalText()
    {
        localScoreText.text = localScore.ToString();
    }

    public void UpdateRemoteText()
    {
        remoteScoreText.text = remoteScore.ToString();
    }
}
