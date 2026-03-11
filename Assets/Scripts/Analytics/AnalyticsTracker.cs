using UnityEngine;

namespace NeonNinja
{
    public class AnalyticsTracker : MonoBehaviour
    {
        // NOTE: Make sure to import the Firebase Analytics SDK to fully implement these log methods.
        
        void Start()
        {
            Debug.Log("Analytics: Initialized Firebase/Unity Analytics placeholder");
        }

        public void LogSlashFired()
        {
            // FirebaseAnalytics.LogEvent("SlashFired");
            Debug.Log("Analytics Event: SlashFired");
        }

        public void LogFocusBurst()
        {
            // FirebaseAnalytics.LogEvent("FocusBurst");
            Debug.Log("Analytics Event: FocusBurst");
        }

        public void LogRuneCollected()
        {
            // FirebaseAnalytics.LogEvent("RuneCollected");
            Debug.Log("Analytics Event: RuneCollected");
        }

        public void LogLevelComplete(int finalScore)
        {
            // FirebaseAnalytics.LogEvent("LevelComplete", new Parameter("score", finalScore));
            Debug.Log($"Analytics Event: LevelComplete, Score: {finalScore}");
        }
    }
}
