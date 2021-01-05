using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class GameManager : MonoBehaviourPunCallbacks
{
    public float SceneTime;

    public Text Player1ScoreText;
    public Text Player2ScoreText;

    public string P1Choise;
    public string P2Choise;

    public GameObject LogicPrefab;

    public Slider TimerSlider;
    public float gameTime;
    private bool stopTimer;

    private string P1status = "";
    private string P2status = "";

    long S = 0;
    DateTime currentDate;
    DateTime centuryBegin;

    Player[] Players = PhotonNetwork.PlayerList; 

    public void Start()
    {
        Players = PhotonNetwork.PlayerList;
        SetTimer();
        PhotonNetwork.Instantiate(LogicPrefab.name, new Vector3(0, 0, 0), Quaternion.identity);
        string Choise = "none";
        PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Choise", Choise } });
        PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Choise", Choise } });

        if (PhotonNetwork.LocalPlayer == Players[0]) P1status = " (you)";
        if (PhotonNetwork.LocalPlayer == Players[1]) P2status = " (you)";

        Player1ScoreText.text = Players[0].NickName + P1status + " - " + PhotonNetwork.CurrentRoom.CustomProperties["P1Score"].ToString();
        Player2ScoreText.text = Players[1].NickName + P2status + " - " + PhotonNetwork.CurrentRoom.CustomProperties["P2Score"].ToString();
    }
    public void SetTimer()
    {
        PlayerPrefs.SetInt("GoNext0", 0);
        PlayerPrefs.SetInt("GoNext1", 0);
        gameTime *= 1000;
        currentDate = DateTime.Now;
        centuryBegin = new DateTime(2020, 1, 1);
        S = currentDate.Ticks - centuryBegin.Ticks;
        SceneTime = 0;
        stopTimer = false;
        TimerSlider.maxValue = gameTime;
        TimerSlider.value = gameTime;
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(5);
    }
    public void FixedUpdate()
    {
        P1Choise = PhotonNetwork.CurrentRoom.CustomProperties["P1Choise"].ToString();
        P2Choise = PhotonNetwork.CurrentRoom.CustomProperties["P2Choise"].ToString();
        currentDate = DateTime.Now;
        long temp = currentDate.Ticks - centuryBegin.Ticks;
        SceneTime = (temp - S)/10000;
        TimerUpdate();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Leave();
    }
    public void TimerUpdate()
    {
        float time = gameTime - SceneTime;
        if (PhotonNetwork.LocalPlayer == Players[0])
        {
            if (time <= 0 && PlayerPrefs.GetInt("GoNext0") == 0)
            {
                PlayerPrefs.SetInt("GoNext0", 1);
                stopTimer = true;
                PhotonNetwork.LoadLevel(9);
            }
            if(PlayerPrefs.GetInt("GoNext0") == 0 && P1Choise != "none" && P2Choise != "none" && SceneTime > 3000 )
            {
                PlayerPrefs.SetInt("GoNext0", 1);
                stopTimer = true;
                PhotonNetwork.LoadLevel(9);
            }
        }

        if (PhotonNetwork.LocalPlayer == Players[1])
        {
            if (time <= 0 && PlayerPrefs.GetInt("GoNext1") == 0)
            {
                PlayerPrefs.SetInt("GoNext1", 1);
                stopTimer = true;
                PhotonNetwork.LoadLevel(9);
            }
            if (PlayerPrefs.GetInt("GoNext1") == 0 && P1Choise != "none" && P2Choise != "none" && SceneTime > 3000)
            {
                PlayerPrefs.SetInt("GoNext1", 1);
                stopTimer = true;
                PhotonNetwork.LoadLevel(9);
            }
        }
        if (stopTimer == false)
        {
            TimerSlider.value = time;
        }
    }
}
