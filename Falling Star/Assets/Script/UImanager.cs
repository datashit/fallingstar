using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayMenuPanel;
    public GameObject LostMenuPanel;
    public GameObject OrbStorePanel;

    public GameManager gameManager;

    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    private GameObject ActiveUIobject;

    public void Start()
    {
        ActiveUIobject = MainMenuPanel;
    }
    public void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
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

    public void Click_Orb_Shop()
    {
        //MainMenuPanel.SetActive(false);
        //OrbStorePanel.SetActive(true);
        ChangeUI(OrbStorePanel);
    }

    public void Click_Play_Button()
    {
        ChangeUI(PlayMenuPanel);
        //MainMenuPanel.SetActive(false);
        //PlayMenuPanel.SetActive(true);
        gameManager.PlayGame = true;
    }
    public void Click_Pause_Button()
    {
        if (gameManager.PlayGame)
        {
            gameManager.PlayGame = false;
            ChangeUI(LostMenuPanel);
            //PlayMenuPanel.SetActive(false);
            //LostMenuPanel.SetActive(true);
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
        ChangeUI(MainMenuPanel);
        //LostMenuPanel.SetActive(false);
        //PlayMenuPanel.SetActive(false);
        //OrbStorePanel.SetActive(false);
        //MainMenuPanel.SetActive(true);
        gameManager.PlayGame = false;
    }



    private void ChangeUI(GameObject UI)
    {
        if (ActiveUIobject != null)
        {
            ActiveUIobject.SetActive(false);
        }
        ActiveUIobject = UI;
        ActiveUIobject.SetActive(true);
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
