using UnityEngine;
using System.Collections;

public class OrbManager : MonoBehaviour
{


    private static OrbManager instance = null;

    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;

        DontDestroyOnLoad(instance);
    }



    public static OrbManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void UpdateTotalOrb(int orb)
    {
        
        PlayerPrefs.SetInt("OrbPoint", PlayerPrefs.GetInt("OrbPoint",0) + orb);
    }


}
