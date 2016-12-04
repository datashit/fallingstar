using UnityEngine;


public class OrbManager : BaseBehaviour
{
    public enum OrbManagerInfo
    {
        ORB_SCORE_CHANGE,
        TOTAL_ORB_CHANGE
    }

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


    /// <summary>
    /// Toplam Orb prefs tutucu ismi
    /// </summary>
    private const string sTotalOrb = "OrbPoint";

    private int orb = 0;
    /// <summary>
    /// Orb score sayısı
    /// </summary>
    public int getOrb
    {
        get { return orb; }
    }

    /// <summary>
    /// Toplam Orb Sayısı.
    /// </summary>
    public int getTotalOrb
    {
        get
        {
            return PlayerPrefs.GetInt(sTotalOrb, 0);
        }
    }


    /// <summary>
    /// Orb Score ekleyen metod
    /// </summary>
    /// <param name="value">Eklenmek istenen değer</param>
    /// <returns>Yeni Orb Score</returns>
    public int AddOrb(int value)
    {
        ChangeOrb(this.orb + value);
        return this.orb;
    }


    /// <summary>
    /// Orb skoru toplam orb'a ekleyen metod.
    /// </summary>
    public void UpdateTotalOrb()
    {
        int orbScore = this.orb;
        ChangeOrb(0);

        AddTotalOrb(orbScore);
    }


    /// <summary>
    /// Orb score ' a değer atayan metod.
    /// </summary>
    /// <param name="value"></param>
    private void ChangeOrb(int value)
    {
        this.orb = value;
        Observer.SendMessage(OrbManagerInfo.ORB_SCORE_CHANGE, this.orb);
    }



    /// <summary>
    /// Toplam Orb değerine verilen sayıyı ekeleyen metod
    /// </summary>
    /// <param name="value">Eklenecek orb sayısı</param>
    /// <returns>Yeni Güncel Toplam Orb Döner</returns>
    public int AddTotalOrb(int value)
    {
        int newVal = getTotalOrb + value;
        ChangeTotalOrb(newVal);
        return newVal;
    }

    /// <summary>
    /// Toplam Orb değerini verilen sayı ile değiştirir
    /// </summary>
    /// <param name="value">Yeni orb sayısı</param>
    private void ChangeTotalOrb(int value)
    {
        PlayerPrefs.SetInt(sTotalOrb, value);
        Observer.SendMessage(OrbManagerInfo.TOTAL_ORB_CHANGE, value);
    }

    /// <summary>
    /// Toplam Orb Harcamak için kullanılan metod
    /// </summary>
    /// <param name="value">Harcanılacak orb</param>
    /// <returns> Başarılı ise true değilse false döner.</returns>
    public bool SpendTotalOrb(int value)
    {
        bool succes = false;
        int ActualTotalOrb = getTotalOrb;

        if (ActualTotalOrb > 0  //Sıfırdan büyük
            && !((ActualTotalOrb - value) < 0)) // Çıkan sonuç negatif değil ise
        {
            ChangeTotalOrb(ActualTotalOrb - value);
            succes = true;
        }
        return succes;
    }
  


}
