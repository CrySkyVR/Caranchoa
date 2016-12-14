using UnityEngine;
using StartApp;
using System;

public class StartAppADS : MonoBehaviour {
    private Listener listener;

	void Start () {
        if (isAndroidDevice() == false) return;
        StartAppWrapper.init();
        launchBanner();
    }

    public void launchInterestial() {
        if (isAndroidDevice() == false) return;
        listener = new Listener();
        StartAppWrapper.loadAd(StartAppWrapper.AdMode.FULLPAGE, listener);
    }

    private void launchBanner() {
        StartAppWrapper.addBanner(
             StartAppWrapper.BannerType.AUTOMATIC,
             StartAppWrapper.BannerPosition.BOTTOM);
    }

    private bool isAndroidDevice() {
        return (Application.platform == RuntimePlatform.Android);
    }
}

class Listener : StartAppWrapper.AdEventListener {

    public void onFailedToReceiveAd() {
        Debug.Log("Error. Ad not received from StartApp");
        
    }

    public void onReceiveAd() {
        Debug.Log("Ad received. Show ad");
        StartAppWrapper.showAd();
    }
}
