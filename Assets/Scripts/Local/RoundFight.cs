using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundFight : MonoBehaviour
{
    public Button NextTurn;

    public Text AIWin;
    public Text PlayerWin;

    public Image AIImage;
    public Image PlayerImage;

    public Sprite WinRock;
    public Sprite WinScissors;
    public Sprite WinPaper;
    
    public Sprite LoseRock;
    public Sprite LoseScissors;
    public Sprite LosePaper;

    public Image PlayerBackground;
    public Image AIBackground;

    public Color Win;
    public Color Lose;

    int Rock = 1;
    int Paper = 2;
    int Scissors = 3;
    void Start()
    {
        int PlayerChoise = PlayerPrefs.GetInt("PlayerChoise");
        int AIChoise = Random.Range(1, 4);
        
        if(PlayerChoise == Rock && AIChoise == Scissors)
        {
            WinPlayer();
            PlayerImage.sprite = WinRock;
            AIImage.sprite = LoseScissors;
        }
        if(PlayerChoise == Scissors && AIChoise == Paper)
        {
            WinPlayer();
            PlayerImage.sprite = WinScissors;
            AIImage.sprite = LosePaper;
        }
        if(PlayerChoise == Paper && AIChoise == Rock)
        {
            WinPlayer();
            PlayerImage.sprite = WinPaper;
            AIImage.sprite = LoseRock;
        }

        if(AIChoise == Rock && PlayerChoise == Scissors)
        {
            WinAI();
            PlayerImage.sprite = LoseScissors;
            AIImage.sprite = WinRock;
        }
        if(AIChoise == Scissors && PlayerChoise == Paper)
        {
            WinAI();
            PlayerImage.sprite = LosePaper;
            AIImage.sprite = WinScissors;
        }
        if(AIChoise == Paper && PlayerChoise == Rock)
        {
            WinAI();
            PlayerImage.sprite = LoseRock;
            AIImage.sprite = WinPaper;
        }


        if(PlayerChoise == AIChoise)
        {
            AIWin.text = "Draw";
            PlayerWin.text = "Draw";
            PlayerBackground.color = Win;
            AIBackground.color = Win;

            switch(PlayerChoise)
            {
            case 1:
                    PlayerImage.sprite = WinRock;
                   AIImage.sprite = WinRock;
                    break;
            case 2:
                    PlayerImage.sprite = WinPaper;
                    AIImage.sprite = WinPaper;
                    
                    break;
            case 3:
                    PlayerImage.sprite = WinScissors;
                    AIImage.sprite = WinScissors;

                    break;
            }
        }


        Button button_NextTurn = NextTurn.GetComponent<Button>();
        if (PlayerPrefs.GetInt("PlayerScore") == PlayerPrefs.GetInt("RoundCounter"))
        {
            PlayerPrefs.SetInt("GameState", 1);
            button_NextTurn.onClick.AddListener(GoToRoundEnd);
        }
        else if (PlayerPrefs.GetInt("AIScore") == PlayerPrefs.GetInt("RoundCounter"))
        {
            PlayerPrefs.SetInt("GameState", 0);
            button_NextTurn.onClick.AddListener(GoToRoundEnd);
        }
        else
        {
            button_NextTurn.onClick.AddListener(GoToNextTurn);
        }
    }

    void GoToNextTurn()
    {
        SceneManager.LoadScene(2);
    }
    void GoToRoundEnd()
    {
        SceneManager.LoadScene(4);
    }
    void WinAI()
    {
        PlayerPrefs.SetInt("AIScore", PlayerPrefs.GetInt("AIScore") + 1);
        AIBackground.color = Win;
        PlayerBackground.color = Lose;
        AIWin.text = "AI Win";
        PlayerWin.text = "You Lose";
    }
    void WinPlayer()
    {
        PlayerPrefs.SetInt("PlayerScore", PlayerPrefs.GetInt("PlayerScore") + 1);
        AIBackground.color = Lose;
        PlayerBackground.color = Win;
        AIWin.text = "AI Lose";
        PlayerWin.text = "You Win";
    }
}
