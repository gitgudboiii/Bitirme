using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;



public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    public static AdsManager instance;

    string gameID = "4802955";
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID);
        Advertisement.AddListener(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAd()
    {
        if(Advertisement.IsReady("Interstitial_Android"))
        {
            Advertisement.Show("Interstitial_Android");
        }
    }

    public void ShowRewardedAd()
    {
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
    
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {

        if(showResult == ShowResult.Finished)
        {
            

        }
        GameManager.instance.LevelReload();
    }
}
