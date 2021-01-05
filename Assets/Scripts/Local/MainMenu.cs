using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button PlayOffline;
    public Button PlayOnline;
    void Start()
    {
        Button button_PlayOffline = PlayOffline.GetComponent<Button>();
        Button button_PlayOnline = PlayOnline.GetComponent<Button>();

        button_PlayOffline.onClick.AddListener(GoToRoundPicker);
        button_PlayOnline.onClick.AddListener(GoToMultiplayer);
    }

    void GoToRoundPicker()
    {
        SceneManager.LoadScene(1);
    }
    void GoToMultiplayer()
    {
        SceneManager.LoadScene(5);
    }
}
