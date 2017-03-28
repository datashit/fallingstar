using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Script;

public class UImanager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject PlayMenuPanel;
    public GameObject LostMenuPanel;
    public GameObject OrbStorePanel;
    public GameObject PauseMenuPanel;

    public MMAnimationScript mmAnimationScript;

    public GameManager gameManager;

    public Sprite MusicOnSprite;
    public Sprite MusicOffSprite;

    private GameObject ActiveUIobject;

    public enum PageEnum
    {
        MainMenu,
        PlayGame,
        PauseGame,
        LostGame,
        Market,
        OrbShop
    }
    PageEnum activePage;
    public void Start()
    {
        
        ActiveUIobject = MainMenuPanel;
        activePage = PageEnum.MainMenu;
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
        activePage = PageEnum.OrbShop;
        AdManager.Instance.HideBanner();
        
    }

    private void Play_Time()
    {
        gameManager.PlayGame = true;
        AdManager.Instance.ShowBanner();
        GameProperties.IncGamePlayCount();
        gameManager.Play();
    }

    public void Click_Play_Button()
    {
        ChangeUI(PlayMenuPanel);
        activePage = PageEnum.PlayGame;
        Play_Time();
    }

    public void Click_Replay_Button()
    {
        ChangeUI(PlayMenuPanel);
        activePage = PageEnum.PlayGame;
        Play_Time();
    }
    public void Click_Pause_Button()
    {
        if (Time.timeScale != 0)
        {
            //gameManager.PlayGame = false;
            ChangeUI(PauseMenuPanel);
            //PlayMenuPanel.SetActive(false);
            //LostMenuPanel.SetActive(true);
            Time.timeScale = 0;
            activePage = PageEnum.PauseGame;
        }
    }

    public void Click_Pause_Play_Button()
    {
        if (Time.timeScale == 0)
        {
            //gameManager.PlayGame = true;
            ChangeUI(PlayMenuPanel);
            //PlayMenuPanel.SetActive(false);
            //LostMenuPanel.SetActive(true);
            Time.timeScale = 1;
            activePage = PageEnum.PlayGame ;
        }
    }

    public void Click_MainMenu_Button()
    {
        Load_MainMenu();
        gameManager.Reload_Game();
    }

    private void Exit_PlayMode()
    {
        gameManager.PlayGame = false;
        AdManager.Instance.HideBanner();
    }

    public void Load_MainMenu()
    {
        ChangeUI(MainMenuPanel);
        activePage = PageEnum.MainMenu;
        Exit_PlayMode();
        mmAnimationScript.Back_MM_Animation();    
    }

    public void Load_LostMenu(int score, bool earn)
    {
        ChangeUI(LostMenuPanel);
        activePage = PageEnum.LostGame;
        Exit_PlayMode();
        GameObject.Find("Text_SCORE_NUMBER").GetComponent<Text>().text = score.ToString();
        GameObject.Find("LostMenuPanel").GetComponent<LostPanelScript>().EarnButtonVisible(earn);
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
