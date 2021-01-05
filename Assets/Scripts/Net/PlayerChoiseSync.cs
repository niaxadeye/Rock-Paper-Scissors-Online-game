using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerChoiseSync : MonoBehaviourPun
{
    public GameObject Rock;
    public GameObject Scissors;
    public GameObject Paper;
    
    public void Start()
    {

        Rock = GameObject.Find("Rock");
        Scissors = GameObject.Find("Scissors");
        Paper = GameObject.Find("Paper");
        Button button_Rock = Rock.GetComponent<Button>();
        Button button_Scissors = Scissors.GetComponent<Button>();
        Button button_Paper = Paper.GetComponent<Button>();
        button_Rock.onClick.AddListener(pressRock);
        button_Scissors.onClick.AddListener(pressScissors);
        button_Paper.onClick.AddListener(pressPaper);

    }
    public void pressRock()
    {
        if (photonView.IsMine)
        {
            string Choise = "Rock";
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Choise", Choise } });
            }
            else
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Choise", Choise } });
            }
        }
    }
    public void pressScissors()
    {
        if (photonView.IsMine)
        {
            string Choise = "Scissors";
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Choise", Choise } });
            }
            else
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Choise", Choise } });
            }
        }
    }
    public void pressPaper()
    {
        if (photonView.IsMine)
        {
            string Choise = "Paper";
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P1Choise", Choise } });
            }
            else
            {
                PhotonNetwork.CurrentRoom.SetCustomProperties(new Hashtable() { { "P2Choise", Choise } });
            }
        }
    } 
}
