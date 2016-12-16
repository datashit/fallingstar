using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobManager : MonoBehaviour
{

#if UNITY_EDITOR
    const string banneradUnitId = "unused";
    const string interstitialadUnitId = "unused";
#elif UNITY_ANDROID
    const  string banneradUnitId = "ca-app-pub-9156853720163935/4918674802";
    const  string interstitialadUnitId = "ca-app-pub-9156853720163935/7872141208";
#elif UNITY_IPHONE
    const  string banneradUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
    const  string interstitialadUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
#else
    const  string banneradUnitId = "unexpected_platform";
    const  string interstitialadUnitId = "unexpected_platform";
#endif
    private static AdMobManager instance = null;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;


        DontDestroyOnLoad(instance);
    }

    BannerView bannerView;
    InterstitialAd interstitial;
    public void Start()
    {
        bannerView = new BannerView(banneradUnitId, AdSize.Banner, AdPosition.Bottom);
        interstitial = new InterstitialAd(interstitialadUnitId);
        RequestBanner();
        RequestInterstitial();
    }

    public static AdMobManager Instance
    {
        get { return instance; }
    }

    public void ShowBanner()
    {
        bannerView.Show();
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    private AdRequest newAdRequest()
    {
        return new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
    }

    private void RequestBanner()
    {
        // Load the banner with the request.
        bannerView.LoadAd(newAdRequest());
    }

    
 
    public void RequestInterstitial()
    {   
        // Load the interstitial with the request.
        interstitial.LoadAd(newAdRequest());
    }
}
