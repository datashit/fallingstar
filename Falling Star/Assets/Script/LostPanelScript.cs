using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostPanelScript : MonoBehaviour {

    public GameObject EarnButton;

    public void EarnButtonVisible( bool visible)
    {
        EarnButton.active = visible;
    }
}
