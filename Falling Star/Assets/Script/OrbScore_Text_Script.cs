using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OrbScore_Text_Script : BaseBehaviour
{
    public void Awake()
    {
        Observer.AddListener(PlayerControl.PlayerInfo.ORB_SCORE_CHANGE, this, UpdateText);
    }

    private void UpdateText(ObservParam obj)
    {
        this.GetComponent<Text>().text = string.Format("{0}", (uint)obj.data);
    }
}
