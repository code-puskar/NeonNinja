using UnityEngine;
using System.Collections;

namespace NeonNinja
{
    public class FocusBurst : MonoBehaviour
    {
        public FocusMeter focusMeter;
        public RewardManager rewardManager;
        public ParticleSystem focusBurstVFX;

        void Start()
        {
            if (focusMeter != null)
            {
                focusMeter.OnFull.AddListener(TriggerFocusBurst);
            }
        }

        private void TriggerFocusBurst()
        {
            StartCoroutine(FocusBurstRoutine());
        }

        private IEnumerator FocusBurstRoutine()
        {
            Time.timeScale = 0.2f;
            
            if (rewardManager != null)
            {
                rewardManager.SetMultiplier(2);
            }

            if (focusBurstVFX != null)
            {
                focusBurstVFX.Play();
            }

            yield return new WaitForSecondsRealtime(3f);

            Time.timeScale = 1f;

            if (rewardManager != null)
            {
                rewardManager.SetMultiplier(1);
            }

            if (focusMeter != null)
            {
                focusMeter.ResetFocus();
            }
        }
    }
}
