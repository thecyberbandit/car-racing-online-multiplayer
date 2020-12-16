using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviourPun
{
    public static UIManager instance;

    public Text localPlayerName;
    public Text remotePlayerName;
    public Image localPlayerImage;
    public Image remotePlayerImage;

    private PhotonView PV;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PV = GetComponent<PhotonView>();

        SetPlayerNames();
        SetPlayerImages();
    }

    void SetPlayerNames()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            string masterName = PlayerPrefs.GetString("MasterName");
            localPlayerName.text = masterName;

            PV.RPC("RPC_UpdateName", RpcTarget.Others, masterName);
        }

        else
        {
            string clientName = PlayerPrefs.GetString("ClientName");
            localPlayerName.text = clientName;

            PV.RPC("RPC_UpdateName", RpcTarget.MasterClient, clientName);
        }
    }

    void SetPlayerImages()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int masterImage = PlayerPrefs.GetInt("MasterImage");
            localPlayerImage.sprite = GameSetupController.instance.playerImages[masterImage];

            PV.RPC("RPC_UpdatePicture", RpcTarget.Others, masterImage);
        }

        else
        {
            int clientImage = PlayerPrefs.GetInt("ClientImage");
            localPlayerImage.sprite = GameSetupController.instance.playerImages[clientImage];

            PV.RPC("RPC_UpdatePicture", RpcTarget.MasterClient, clientImage);
        }
    }

    [PunRPC]
    public void RPC_UpdateName(string name)
    {
        remotePlayerName.text = name;
    }

    [PunRPC]
    public void RPC_UpdatePicture(int index)
    {
        remotePlayerImage.sprite = GameSetupController.instance.playerImages[index];
    }
}
