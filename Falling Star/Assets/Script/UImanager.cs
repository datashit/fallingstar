using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
    public GameObject MainMenuPanel;
    public GameObject PlayMenuPanel;
    public GameObject LostMenuPanel;
    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

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
    }
    public void Click_Pause_Button()
    {
        PlayMenuPanel.active = false;
        LostMenuPanel.active = true;
    }
    public void Click_MainMenu_Button()
    {
        LostMenuPanel.active = false;
        MainMenuPanel.active = true;
    }

    public void Click_MusicOnOff_Button()
    {
        GameObject MusicOnOffButton = GameObject.Find("MusicOnOffButton");
        switch(musicStatus)
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
