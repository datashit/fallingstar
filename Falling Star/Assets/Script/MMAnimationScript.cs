using UnityEngine;
using System.Collections;

public class MMAnimationScript : MonoBehaviour {


    public UImanager uiManager;
    private Animation anim;

    public void Awake()
    {
        anim = this.GetComponent<Animation>();
    }

    enum ePlayAnim
    {
        IDLE,
        PLAY_BUTTON_CLICK,
        BACK_MAIN_MENU
    }
    ePlayAnim state = ePlayAnim.IDLE;
    public void Play_BTN_Click_Animation_End()
    {
        if(state == ePlayAnim.PLAY_BUTTON_CLICK)
        {
            state = ePlayAnim.IDLE;
            uiManager.Click_Play_Button();
            anim.Stop();
        }
       
    }
    public void Play_BTN_Click_Animation_Begin()
    {
        if (state == ePlayAnim.BACK_MAIN_MENU)
        {
            state = ePlayAnim.IDLE;
            anim.Stop();
        }
    }
    public void Back_MM_Animation()
    {
        anim.Play("MainMenuBack");
    }

    public void Play_Button_Click_Animation()
    {
        state = ePlayAnim.PLAY_BUTTON_CLICK;
        anim.Play("MainMenuPlay");
    }
}
