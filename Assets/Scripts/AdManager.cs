using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{

    public static AdManager Instance;
    private GameOverHandler gameOverHandler;
    [SerializeField] private bool testMode = true;

#if UNITY_ANDROID
    private string gameId = "5001867";
#elif UNITY_IOS
    private string gameId = "5001866";
#endif

    void Awake()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler){
        this.gameOverHandler = gameOverHandler;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult){
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogWarning($"Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }



}
