using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Total_Orb_Text_Script : BaseBehaviour
{
    public void Awake()
    {
        Observer.AddListener(PlayerControl.PlayerInfo.TOTAL_ORB_SCORE_CHANGE, this, UpdateText_Observer);
        UpdateText(PlayerPrefs.GetInt("OrbPoint",0));
    }


    private void UpdateText_Observer(ObservParam obj)
    {
        UpdateText((int)obj.data);
    }

    private void UpdateText(int Value)
    {
        this.GetComponent<Text>().text = string.Format("{0}", Value);
    }
}
