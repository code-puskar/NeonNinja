using UnityEngine;
using UnityEngine.Events;

namespace NeonNinja
{
    [CreateAssetMenu(fileName = "NewFocusMeter", menuName = "NeonNinja/Config/FocusMeter")]
    public class FocusMeter : ScriptableObject
    {
        [Range(0, 10)]
        public int currentFocus = 0;
        public int maxFocus = 10;

        public UnityEvent OnFull = new UnityEvent();
        public UnityEvent<int> OnFocusChanged = new UnityEvent<int>();

        public void Add(int amount)
        {
            int previousFocus = currentFocus;
            currentFocus = Mathf.Clamp(currentFocus + amount, 0, maxFocus);
            
            if (currentFocus != previousFocus)
            {
                OnFocusChanged?.Invoke(currentFocus);
            }

            if (currentFocus >= maxFocus && previousFocus < maxFocus)
            {
                OnFull?.Invoke();
            }
        }

        public void ResetFocus()
        {
            currentFocus = 0;
            OnFocusChanged?.Invoke(currentFocus);
        }
    }
}
