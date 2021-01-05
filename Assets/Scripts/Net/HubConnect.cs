using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubConnect : MonoBehaviourPunCallbacks
{   
    public InputField RoomInput;
    void Start()
    {
    }
    public void Back()
    {
        SceneManager.LoadScene(5);
    }
    public void JoinRoom()
    {
        
        PhotonNetwork.JoinRoom(RoomInput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(8);
    }
}
