using UnityEngine;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;

public class Advertising : MonoBehaviour
{
    private void Start()
    {
        int adTypes = AppodealAdType.Interstitial;
        string appKey = "de8d5a191dae572284df85a848f1c35b17f2d793c84e42c1";
        AppodealCallbacks.Sdk.OnInitialized += OnInitializationFinished;
        Appodeal.Initialize(appKey, adTypes);
    }

    public void OnInitializationFinished(object sender, SdkInitializedEventArgs e) { }
}
