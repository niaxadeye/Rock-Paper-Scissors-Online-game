using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetEnd : MonoBehaviourPunCallbacks
{
    public Button PlayAgain;
    public Text Player1ScoreText;
    public Text Player2ScoreText;
    public Text GameState;
    private string P1status = "";
    private string P2status = "";
    void Start()
    {

        var Players = PhotonNetwork.PlayerList;

        if (PhotonNetwork.LocalPlayer == Players[0]) P1status = " (you)";
        if (PhotonNetwork.LocalPlayer == Players[1]) P2status = " (you)";

        if (PhotonNetwork.LocalPlayer == Players[0] && (int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] == 3)
        {
            GameState.text = "You win!";
        }
        if(PhotonNetwork.LocalPlayer == Players[0] && (int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] != 3)
        {
            GameState.text = "You lose";
        }

        if(PhotonNetwork.LocalPlayer == Players[1] && (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"] == 3)
        {
            GameState.text = "You win!";
        }
        if (PhotonNetwork.LocalPlayer == Players[1] && (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"]  != 3)
        {
            GameState.text = "You lose";
        }
        Player1ScoreText.text = Players[0].NickName + P1status + " - " + PhotonNetwork.CurrentRoom.CustomProperties["P1Score"].ToString();
        Player2ScoreText.text = Players[1].NickName + P2status + " - " + PhotonNetwork.CurrentRoom.CustomProperties["P2Score"].ToString();
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(5);
    }
}
