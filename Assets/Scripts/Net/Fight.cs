using Photon.Pun;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class Fight : MonoBehaviourPun
{
    private float SceneTime = 0;

    public Text Player1Nick;
    public Text Player2Nick;

    public Image Player1Image;
    public Image Player2Image;

    public Sprite WinRock;
    public Sprite WinScissors;
    public Sprite WinPaper;

    public Sprite LoseRock;
    public Sprite LoseScissors;
    public Sprite LosePaper;

    public Sprite None;

    public Image Player1Background;
    public Image Player2Background;

    private Color Win = new Color(1.0f, 0.9176471f, 0f);
    private Color Lose = new Color(1.0f, 0.1568628f, 0f);

    private string P1Choise;
    private string P2Choise;

    public Slider TimerSlider;
    public float gameTime;
    private bool stopTimer;

    public Photon.Realtime.Player[] Players = PhotonNetwork.PlayerList;

    private string P1status = "";
    private string P2status = "";

    long S = 0;
    DateTime currentDate;
    DateTime centuryBegin;

    void Start()
    {
        Players = PhotonNetwork.PlayerList;
        PlayerPrefs.SetInt("GoF0", 0);
        PlayerPrefs.SetInt("GoF1", 0);

        gameTime *= 1000;
        currentDate = DateTime.Now;
        centuryBegin = new DateTime(2020, 1, 1);
        S = currentDate.Ticks - centuryBegin.Ticks;
        SceneTime = 0;
        stopTimer = false;
        TimerSlider.maxValue = gameTime;
        TimerSlider.value = gameTime;

        P1Choise = PhotonNetwork.CurrentRoom.CustomProperties["P1Choise"].ToString();
        P2Choise = PhotonNetwork.CurrentRoom.CustomProperties["P2Choise"].ToString();

        if (PhotonNetwork.LocalPlayer == Players[0]) P1status = " (you)";
        if (PhotonNetwork.LocalPlayer == Players[1]) P2status = " (you)";

        
        if (P1Choise == "none" && (P2Choise == "Rock" || P2Choise == "Paper" || P2Choise == "Scissors"))
        {
            Player1Background.color = Lose;
            Player2Background.color = Win;
            Debug.Log("Хост(верх) ничего не выбрал");
            if (PhotonNetwork.LocalPlayer == Players[0])
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Score", (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"] + 1 } });
            }
            Player1Nick.text = Players[0].NickName + P1status + " didn't choose anything";
            Player2Nick.text = Players[1].NickName + P2status + " won!";
            switch (P2Choise)
            {
                case "Rock":
                    Player2Image.sprite = WinRock;
                    break;
                case "Scissors":
                    Player2Image.sprite = WinScissors;
                    break;
                case "Paper":
                    Player2Image.sprite = WinPaper;
                    break;
            }
            Player1Image.sprite = None;
        }
        else if (P2Choise == "none" && (P1Choise == "Rock" || P1Choise == "Paper" || P1Choise == "Scissors"))
        {
            Player1Background.color = Win;
            Player2Background.color = Lose;
            Debug.Log("Клиент(низ) ничего не выбрал");
            if (PhotonNetwork.LocalPlayer == Players[0])
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Score", (int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] + 1 } });
            }
            Player1Nick.text = Players[0].NickName + P1status + " won!";
            Player2Nick.text = Players[1].NickName + P2status + " didn't choose anything";
            switch (P1Choise)
            {
                case "Rock":
                    Player1Image.sprite = WinRock;
                    break;
                case "Scissors":
                    Player1Image.sprite = WinScissors;
                    break;
                case "Paper":
                    Player1Image.sprite = WinPaper;
                    break;
            }
            Player2Image.sprite = None;
        }

        if (P1Choise == "Rock" && P2Choise == "Scissors")
        {
            WinPlayer1();
            Player1Image.sprite = WinRock;
            Player2Image.sprite = LoseScissors;
        }
        if (P1Choise == "Scissors" && P2Choise == "Paper")
        {
            WinPlayer1();
            Player1Image.sprite = WinScissors;
            Player2Image.sprite = LosePaper;
        }
        if (P1Choise == "Paper" && P2Choise == "Rock")
        {
            WinPlayer1();
            Player1Image.sprite = WinPaper;
            Player2Image.sprite = LoseRock;
        }

        if (P2Choise == "Rock" && P1Choise == "Scissors")
        {
            WinPlayer2();
            Player2Image.sprite = WinRock;
            Player1Image.sprite = LoseScissors;
        }
        if (P2Choise == "Scissors" && P1Choise == "Paper")
        {
            WinPlayer2();
            Player2Image.sprite = WinScissors;
            Player1Image.sprite = LosePaper;
        }
        if (P2Choise == "Paper" && P1Choise == "Rock")
        {
            WinPlayer2();
            Player2Image.sprite = WinPaper;
            Player1Image.sprite = LoseRock;
        }

        if (P1Choise == P2Choise)
        {
            Draw();
            switch (P1Choise)
            {
                case "Rock":
                    Player1Image.sprite = WinRock;
                    Player2Image.sprite = WinRock;
                    break;
                case "Scissors":
                    Player1Image.sprite = WinScissors;
                    Player2Image.sprite = WinScissors;
                    break;
                case "Paper":
                    Player1Image.sprite = WinPaper;
                    Player2Image.sprite = WinPaper;
                    break;
                case "none":
                    Player1Image.sprite = None;
                    Player2Image.sprite = None;
                    break;
            }
        }

    }

    public void WinPlayer1()
    {
        Player1Background.color = Win;
        Player2Background.color = Lose;
        if (PhotonNetwork.LocalPlayer == Players[0])
         {
            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Score", (int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] + 1 } });
         }
        Player1Nick.text = Players[0].NickName + P1status + " won!";
        Player2Nick.text = Players[1].NickName + P2status + " lose";
    }
    public void WinPlayer2()
    {
        Player1Background.color = Lose;
        Player2Background.color = Win;
        if (PhotonNetwork.LocalPlayer == Players[0])
        {
            PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Score", (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"] + 1} });
        }
        Player1Nick.text = Players[0].NickName + P1status + " lose";
        Player2Nick.text = Players[1].NickName + P2status + " won!";
    }
    public void Draw()
    {
        var Players = PhotonNetwork.PlayerList;
        Player1Background.color = Win;
        Player2Background.color = Win;

        Player1Nick.text = Players[0].NickName + P1status + " draw";
        Player2Nick.text = Players[1].NickName + P2status + " draw";
    }
    void FixedUpdate()
    {
        currentDate = DateTime.Now;
        long temp = currentDate.Ticks - centuryBegin.Ticks;
        SceneTime = (temp - S) / 10000;
        TimerUpdate();
    }
    public void TimerUpdate()
    {
        float time = gameTime - SceneTime;

        if (PhotonNetwork.LocalPlayer == Players[0])
        {
            if (time <= 0)
            {
                stopTimer = true;

                if (((int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] == 3 || (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"] == 3) && PlayerPrefs.GetInt("GoF0") == 0)
                {
                    PlayerPrefs.SetInt("GoF0", 1);
                    PhotonNetwork.LoadLevel(10);
                }
                else if (PlayerPrefs.GetInt("GoF0") == 0)
                {
                    PlayerPrefs.SetInt("GoF0", 1);
                    PhotonNetwork.LoadLevel(8);
                }
            }
        }
        if (PhotonNetwork.LocalPlayer == Players[1])
        {
            if (time <= 0)
            {
                stopTimer = true;

                if (((int)PhotonNetwork.CurrentRoom.CustomProperties["P1Score"] == 3 || (int)PhotonNetwork.CurrentRoom.CustomProperties["P2Score"] == 3) && PlayerPrefs.GetInt("GoF1") == 0)
                {
                    PlayerPrefs.SetInt("GoF1", 1);
                    PhotonNetwork.LoadLevel(10);
                }
                else if (PlayerPrefs.GetInt("GoF1") == 0)
                {
                    PlayerPrefs.SetInt("GoF1", 1);
                    PhotonNetwork.LoadLevel(8);
                }
            }
        }
        if (stopTimer == false)
        {
            TimerSlider.value = time;
        }
    }
}
