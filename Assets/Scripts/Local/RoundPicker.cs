using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RoundPicker : MonoBehaviour
{
    public Button Play;
    public Button Back;

    public Button DownRound;
    public Button UpRound;

    public Text RoundCounterText;
    void Start()
    {
        PlayerPrefs.SetInt("PlayerScore", 0);
        PlayerPrefs.SetInt("AIScore", 0);
        PlayerPrefs.SetInt("RoundCounter", 3);


        Button button_DownRound = DownRound.GetComponent<Button>();
        Button button_UpRound = UpRound.GetComponent<Button>();

        Button button_Play = Play.GetComponent<Button>();
        Button button_Back = Back.GetComponent<Button>();

        button_Play.onClick.AddListener(GoToWeaponPicker);
        button_Back.onClick.AddListener(GoToMainMenu);

        button_DownRound.onClick.AddListener(RoundMinus);
        button_UpRound.onClick.AddListener(RoundPlus);

    }
    void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    void GoToWeaponPicker()
    {
        SceneManager.LoadScene(2);
    }
    void RoundPlus()
    {
        if(PlayerPrefs.GetInt("RoundCounter") < 6)
        {
            PlayerPrefs.SetInt("RoundCounter", PlayerPrefs.GetInt("RoundCounter") + 1);
        }
        RoundCounterText.text = $"{PlayerPrefs.GetInt("RoundCounter")}";
    }
    void RoundMinus()
    {
        if (PlayerPrefs.GetInt("RoundCounter") > 1)
        {
            PlayerPrefs.SetInt("RoundCounter", PlayerPrefs.GetInt("RoundCounter") - 1);
        }
        RoundCounterText.text = $"{PlayerPrefs.GetInt("RoundCounter")}";
    }
}
