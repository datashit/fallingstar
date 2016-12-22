using UnityEngine;
using Heyzap;


public class AdMobManager : MonoBehaviour
{


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

    public void Start()
    {
        HeyzapAds.Start("e522389493816fef4d0603100a27698b", HeyzapAds.FLAG_NO_OPTIONS);


        /// Reward
        HZIncentivizedAd.AdDisplayListener listener = delegate (string adState, string adTag) {
            if (adState.Equals("incentivized_result_complete"))
            {
                Debug.Log("150 Orb Kazanıldı!");
                // The user has watched the entire video and should be given a reward.
            }
            if (adState.Equals("incentivized_result_incomplete"))
            {
                Debug.Log("Kazanılamadı!");
                // The user did not watch the entire video and should not be given a   reward.
            }
        };

        HZIncentivizedAd.SetDisplayListener(listener);

        HZBannerAd.AdDisplayListener listenerBanner = delegate (string adState, string adTag) {
            if (adState == "loaded")
            {
                Debug.Log("Banner Yüklendi!");
                // Do something when the banner ad is loaded
            }
            if (adState == "error")
            {
                Debug.Log("Banner hatası!");
                // Do something when the banner ad fails to load (they can fail when refreshing after successfully loading)
            }
            if (adState == "click")
            {
                Debug.Log("Banner Tıklandı!");
                // Do something when the banner ad is clicked, like pause your game
            }
        };

        HZBannerAd.SetDisplayListener(listenerBanner);

        HZInterstitialAd.AdDisplayListener listenerInst = delegate (string adState, string adTag) {
            if (adState.Equals("show"))
            {
                Debug.Log("Inst Göster!");
                // Sent when an ad has been displayed.
                // This is a good place to pause your app, if applicable.
            }
            if (adState.Equals("hide"))
            {
                Debug.Log("Inst Gizle!");
                // Sent when an ad has been removed from view.
                // This is a good place to unpause your app, if applicable.
            }
            if (adState.Equals("failed"))
            {
                Debug.Log("Inst Hata!");
                // Sent when you call `show`, but there isn't an ad to be shown.
                // Some of the possible reasons for show errors:
                //    - `HeyzapAds.PauseExpensiveWork()` was called, which pauses 
                //      expensive operations like SDK initializations and ad
                //      fetches, andand `HeyzapAds.ResumeExpensiveWork()` has not
                //      yet been called
                //    - The given ad tag is disabled (see your app's Publisher
                //      Settings dashboard)
                //    - An ad is already showing
                //    - A recent IAP is blocking ads from being shown (see your
                //      app's Publisher Settings dashboard)
                //    - One or more of the segments the user falls into are
                //      preventing an ad from being shown (see your Segmentation
                //      Settings dashboard)
                //    - Incentivized ad rate limiting (see your app's Publisher
                //      Settings dashboard)
                //    - One of the mediated SDKs reported it had an ad to show
                //      but did not display one when asked (a rare case)
                //    - The SDK is waiting for a network request to return before an
                //      ad can show
            }
            if (adState.Equals("available"))
            {
                Debug.Log("Inst Yüklü!");
                // Sent when an ad has been loaded and is ready to be displayed,
                //   either because we autofetched an ad or because you called
                //   `Fetch`.
            }
            if (adState.Equals("fetch_failed"))
            {
                Debug.Log("Inst Fetch Fail!");
                // Sent when an ad has failed to load.
                // This is sent with when we try to autofetch an ad and fail, and also
                //    as a response to calls you make to `Fetch` that fail.
                // Some of the possible reasons for fetch failures:
                //    - Incentivized ad rate limiting (see your app's Publisher
                //      Settings dashboard)
                //    - None of the available ad networks had any fill
                //    - Network connectivity
                //    - The given ad tag is disabled (see your app's Publisher
                //      Settings dashboard)
                //    - One or more of the segments the user falls into are
                //      preventing an ad from being fetched (see your
                //      Segmentation Settings dashboard)
            }
            if (adState.Equals("audio_starting"))
            {
                Debug.Log("Inst ses kapa!");
                // The ad about to be shown will need audio.
                // Mute any background music.
            }
            if (adState.Equals("audio_finished"))
            {
                Debug.Log("Inst ses aç!");
                // The ad being shown no longer needs audio.
                // Any background music can be resumed.
            }
        };

        HZInterstitialAd.SetDisplayListener(listenerInst);

        ShowBanner();

    }



    public static AdMobManager Instance
    {
        get { return instance; }
    }

    public void ShowRewardBasedVideoAd()
    {
        if(HZIncentivizedAd.IsAvailable())
        {
            HZIncentivizedAd.Show();
        }
    }

    public void ShowInterstitial()
    {
        if(HZInterstitialAd.IsAvailable())
        {
            HZInterstitialAd.Show();
        }
    }

    public void RequestRewardAd()
    {
        if(!HZIncentivizedAd.IsAvailable())
        {
            HZIncentivizedAd.Fetch();
        }
    }

    public void ShowBanner()
    {
        HZBannerShowOptions showOptions = new HZBannerShowOptions();
        showOptions.Position = HZBannerShowOptions.POSITION_BOTTOM;
        showOptions.SelectedAdMobSize = HZBannerShowOptions.AdMobSize.SMART_BANNER; // optional, android only
        showOptions.SelectedFacebookSize = HZBannerShowOptions.FacebookSize.SMART_BANNER; // optional, android only
        showOptions.SelectedInmobiSize = HZBannerShowOptions.InmobiSize.BANNER_320_50;
        
        HZBannerAd.ShowWithOptions(showOptions);
        // Load the banner with the request.
        //bannerView.LoadAd(newAdRequest());
    }

    public void HideBanner()
    {
        HZBannerAd.Hide();
    }   
 
    public void RequestInterstitial()
    {   
        if(!HZInterstitialAd.IsAvailable())
        {
            HZInterstitialAd.Fetch();
        }
    }
}
