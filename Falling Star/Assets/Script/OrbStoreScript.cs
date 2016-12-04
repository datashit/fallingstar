using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class OrbStoreScript : MonoBehaviour {

    public void BackMainMenu()
    {
            GameObject.Find("Main Camera").GetComponent<GameManager>().Reload_Game();      
    }

    public void AddTotalOrb(int value)
    {
        OrbManager.Instance.AddTotalOrb(value);
    }
}
