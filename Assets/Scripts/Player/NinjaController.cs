using UnityEngine;

namespace NeonNinja
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NinjaController : MonoBehaviour
    {
        public InputHandler inputHandler;
        public GameObject slashEffectPrefab;
        public FocusMeter focusMeter;
        
        public float forwardSpeed = 5f;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (inputHandler != null)
            {
                inputHandler.OnSwipe.AddListener(HandleSwipe);
            }
        }

        private void HandleSwipe(Vector2 swipeDirection)
        {
            if (slashEffectPrefab != null)
            {
                Vector2 spawnPos = (Vector2)transform.position + swipeDirection * 2f;
                // Instantantiate visual line
                GameObject slash = Instantiate(slashEffectPrefab, spawnPos, Quaternion.identity);
                // Rotate to match swipe direction
                float angle = Mathf.Atan2(swipeDirection.y, swipeDirection.x) * Mathf.Rad2Deg;
                slash.transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            if (focusMeter != null)
            {
                focusMeter.Add(1);
            }
        }

        void FixedUpdate()
        {
            if (GameManager.Instance != null && GameManager.Instance.IsPlaying)
            {
                rb.linearVelocity = new Vector2(forwardSpeed, rb.linearVelocity.y);
            }
            else 
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}
