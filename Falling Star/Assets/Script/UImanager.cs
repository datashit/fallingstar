using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayMenuPanel;
    public GameObject LostMenuPanel;

    public GameManager gameManager;

    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    public void LateUpdate()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Click_Pause_Button();
        }
    }

    enum MusicOnOf
    {
        ON,
        OFF
    };

    private MusicOnOf musicStatus = MusicOnOf.ON;

    public void Click_Play_Button()
    {
        MainMenuPanel.active = false;
        PlayMenuPanel.active = true;
        gameManager.PlayGame = true;
    }
    public void Click_Pause_Button()
    {
        if(gameManager.PlayGame)
        {
            gameManager.PlayGame = false;
            PlayMenuPanel.active = false;
            LostMenuPanel.active = true;
            Time.timeScale = 0;
        }
    }

    public void Click_MainMenu_Button()
    {
        Load_MainMenu();
        gameManager.Reload_Game();
    }

    public void Load_MainMenu()
    {
        LostMenuPanel.active = false;
        PlayMenuPanel.active = false;
        MainMenuPanel.active = true;
        gameManager.PlayGame = false;
    }



    public void Click_MusicOnOff_Button()
    {
        GameObject MusicOnOffButton = GameObject.Find("MusicOnOffButton");
        switch (musicStatus)
        {
            case MusicOnOf.ON:
                musicStatus = MusicOnOf.OFF;
                MusicOnOffButton.GetComponent<Image>().sprite = MusicOffSprite;
                break;
            case MusicOnOf.OFF:
                musicStatus = MusicOnOf.ON;
                MusicOnOffButton.GetComponent<Image>().sprite = MusicOnSprite;
                break;
        }
    }
}
