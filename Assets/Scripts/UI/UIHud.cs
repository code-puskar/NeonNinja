using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace NeonNinja
{
    public class UIHud : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI comboText;
        public Slider focusMeterSlider;

        public RewardManager rewardManager;
        public FocusMeter focusMeter;

        void Update()
        {
            if (rewardManager != null)
            {
                if (scoreText != null)
                {
                    scoreText.text = $"Score: {rewardManager.Score}";
                }
                
                if (comboText != null)
                {
                    comboText.text = rewardManager.Multiplier > 1 ? $"Combo x{rewardManager.Multiplier}" : "";
                }
            }

            if (focusMeter != null && focusMeterSlider != null)
            {
                focusMeterSlider.maxValue = focusMeter.maxFocus;
                focusMeterSlider.value = focusMeter.currentFocus;
            }
        }
    }
}
