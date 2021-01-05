using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WeaponPicker : MonoBehaviour
{
    public Button weapon_Rock;
    public Button weapon_Scissors;
    public Button weapon_Paper;

    public Text AIScoreText;
    public Text PlayerScoreText;
    void Start()
    {
        AIScoreText.text = $"{PlayerPrefs.GetInt("AIScore")}";
        PlayerScoreText.text = $"{PlayerPrefs.GetInt("PlayerScore")}";

        Button button_Rock = weapon_Rock.GetComponent<Button>();
        Button button_Scissors = weapon_Scissors.GetComponent<Button>();
        Button button_Paper = weapon_Paper.GetComponent<Button>();

        button_Rock.onClick.AddListener(SetRock);
        button_Scissors.onClick.AddListener(SetScissors);
        button_Paper.onClick.AddListener(SetPaper);

    }
    void SetRock()
    {
        PlayerPrefs.SetInt("PlayerChoise", 1);
        SceneManager.LoadScene(3);
    }
    void SetPaper()
    {
        PlayerPrefs.SetInt("PlayerChoise", 2);
        SceneManager.LoadScene(3);
    }
    void SetScissors()
    {
        PlayerPrefs.SetInt("PlayerChoise", 3);
        SceneManager.LoadScene(3);
    }
    
  
}
