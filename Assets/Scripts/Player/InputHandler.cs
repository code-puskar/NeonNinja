using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace NeonNinja
{
    public class InputHandler : MonoBehaviour
    {
        public UnityEvent<Vector2> OnSwipe = new UnityEvent<Vector2>();
        
        private Vector2 startPos;
        private float startTime;

        public float minSwipeDistance = 50f;
        public float maxSwipeTime = 1f;
        
        private InputAction touchAction;
        private InputAction touchPositionAction;

        void Awake()
        {
            // Using a generic action setup for swipe detection
            touchAction = new InputAction("Touch", binding: "<Pointer>/press");
            touchPositionAction = new InputAction("TouchPosition", binding: "<Pointer>/position");

            touchAction.started += ctx => 
            {
                startPos = touchPositionAction.ReadValue<Vector2>();
                startTime = Time.time;
            };

            touchAction.canceled += ctx =>
            {
                Vector2 endPos = touchPositionAction.ReadValue<Vector2>();
                float duration = Time.time - startTime;

                if (duration <= maxSwipeTime)
                {
                    Vector2 swipeDirection = endPos - startPos;
                    if (swipeDirection.magnitude >= minSwipeDistance)
                    {
                        OnSwipe?.Invoke(swipeDirection.normalized);
                    }
                }
            };
        }

        void OnEnable()
        {
            touchAction.Enable();
            touchPositionAction.Enable();
        }

        void OnDisable()
        {
            touchAction.Disable();
            touchPositionAction.Disable();
        }
    }
}
