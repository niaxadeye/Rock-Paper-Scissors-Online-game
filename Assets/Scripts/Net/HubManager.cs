using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class HubManager : MonoBehaviourPunCallbacks
{
    public InputField Nick;
    string number;
    public Text Wait;
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            Wait.text = "Connected";
        }
        else
        {
            number = Random.Range(100, 1000).ToString();
            PlayerPrefs.SetString("GameID", number);
            PhotonNetwork.NickName = "Player " + number;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
        Nick.text = PhotonNetwork.LocalPlayer.NickName;
    }
    public void CreateRoom()
    {
        Hashtable RoomCustomProps = new Hashtable();
        RoomCustomProps.Add("P1Choise", "none");
        RoomCustomProps.Add("P2Choise", "none");
        RoomCustomProps.Add("P1Score", 0);
        RoomCustomProps.Add("P2Score", 0);
        PhotonNetwork.CreateRoom(PlayerPrefs.GetString("GameID"), new Photon.Realtime.RoomOptions { MaxPlayers = 2 , BroadcastPropsChangeToAll = true, CustomRoomProperties = RoomCustomProps }) ;
    }
    public void JoinRoom()
    {
        if (Nick.text == "") PhotonNetwork.LocalPlayer.NickName = "Player " + number;
        PhotonNetwork.JoinRoom(PlayerPrefs.GetString("GameID"));
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("CreateGame");
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToConnect()
    {
        if(Nick.text == "") PhotonNetwork.LocalPlayer.NickName = "Player " + number;
        PhotonNetwork.LoadLevel(7);
    }
    public override void OnConnectedToMaster()
    {
        Wait.text = "Connected";
        Debug.Log("Connected to Master");
    }
    public void Update()
    {
        PhotonNetwork.LocalPlayer.NickName = Nick.text;
    }
}
