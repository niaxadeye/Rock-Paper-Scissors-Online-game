using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundEnd : MonoBehaviour
{
    public Button PlayAgain;

    public Text PlayerScoreText;
    public Text AIScoreText;
    public Text GameState;
    void Start()
    {
        switch (PlayerPrefs.GetInt("GameState"))
        {
            case 0:
                GameState.text = "You lose :(";
                break;
            case 1:
                GameState.text = "You WIN!";
                break;
        }
        PlayerScoreText.text = $"{PlayerPrefs.GetInt("PlayerScore")}";
        AIScoreText.text = $"{PlayerPrefs.GetInt("AIScore")}";
        


        Button button_PlayAgain = PlayAgain.GetComponent<Button>();
        button_PlayAgain.onClick.AddListener(GoToRoundPicker);
    }

    void GoToRoundPicker()
    {
        SceneManager.LoadScene(1);
    }
    void Update()
    {
        
    }
}
