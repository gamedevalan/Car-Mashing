using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private InputField createGameInput;
    [SerializeField] private InputField joinGameInput;
    bool connected = false;
    public GameObject inputs;
    public GameObject connectingCanvas;

    public Text connectingToMaster;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        connectingToMaster.text = "CONNECTING";
        if (!connected)
        {
            StartCoroutine(Connecting());
        }
    }


    private void Update()
    {
        connectingCanvas.SetActive(!connected);
        inputs.SetActive(connected);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected");
        connected = true;
    }

    public void CreateRoom()
    {
        if (!createGameInput.text.Equals("")) {
            PhotonNetwork.CreateRoom(createGameInput.text);
        }
    }

    public void JoinRoom()
    {
        if (!joinGameInput.text.Equals(""))
        {
            PhotonNetwork.JoinRoom(joinGameInput.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Multiplayer");
    }

    public static void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Modes");
    }

    public void Back()
    {
        PhotonNetwork.Disconnect();
        PhotonNetwork.LoadLevel("Modes");
    }

    IEnumerator Connecting()
    {
        while (!connected)
        {
            yield return new WaitForSeconds(1f);
            connectingToMaster.text += ".";
        }
    }

}
