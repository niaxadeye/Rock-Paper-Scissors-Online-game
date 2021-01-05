using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HubCreate : MonoBehaviourPunCallbacks
{
    public Text GameID;
    void Start()
    {
        PlayerPrefs.SetInt("GoF", 0);
        GameID.text = "Game ID: " + PlayerPrefs.GetString("GameID");
        
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    private void FixedUpdate()
    {
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PlayerPrefs.GetInt("GoF") == 0)
            {
                PlayerPrefs.SetInt("GoF", 1);
                PhotonNetwork.LoadLevel(8);
            }
            
        }
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(5);
    }
}