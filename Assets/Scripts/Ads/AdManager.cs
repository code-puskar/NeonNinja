using UnityEngine;
using UnityEngine.Events;

namespace NeonNinja
{
    public class AdManager : MonoBehaviour
    {
        [Header("Events")]
        public UnityEvent OnAdLoaded;
        public UnityEvent OnAdFailedToLoad;
        public UnityEvent OnRewardedAdCompleted;
        public UnityEvent OnRewardedAdSkipped;

        // NOTE: Requires Unity Mediation or Unity Ads package to implement real functionality.

        public void LoadAd()
        {
            Debug.Log("AdManager: Loading Rewarded Ad from Unity Mediation...");
            // Simulate successful ad load
            OnAdLoaded?.Invoke();
        }

        public void ShowRewardedAd()
        {
            Debug.Log("AdManager: Showing Rewarded Ad...");
            // Simulate successful ad watch completion
            OnRewardedAdCompleted?.Invoke();
        }
    }
}
