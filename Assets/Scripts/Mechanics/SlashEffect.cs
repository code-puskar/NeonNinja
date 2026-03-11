using UnityEngine;

namespace NeonNinja
{
    [RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
    public class SlashEffect : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private EdgeCollider2D edgeCollider;
        private Vector2[] points = new Vector2[2];
        
        public float lifetime = 0.5f;

        void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            edgeCollider = GetComponent<EdgeCollider2D>();
            lineRenderer.positionCount = 2;
        }

        public void StartSlash(Vector2 startPos)
        {
            points[0] = startPos;
            points[1] = startPos;
            UpdateLineRenderer();
        }

        public void UpdateSlash(Vector2 currentPos)
        {
            points[1] = currentPos;
            UpdateLineRenderer();
        }

        public void EndSlash(Vector2 endPos)
        {
            points[1] = endPos;
            UpdateLineRenderer();
            UpdateCollider();
            
            Destroy(gameObject, lifetime);
        }

        private void UpdateLineRenderer()
        {
            lineRenderer.SetPosition(0, points[0]);
            lineRenderer.SetPosition(1, points[1]);
        }

        private void UpdateCollider()
        {
            var colliderPoints = new System.Collections.Generic.List<Vector2> 
            { 
                transform.InverseTransformPoint(points[0]), 
                transform.InverseTransformPoint(points[1]) 
            };
            edgeCollider.SetPoints(colliderPoints);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (RewardManager.Instance != null)
                {
                    RewardManager.Instance.AddScore(100);
                }

                var ninja = FindFirstObjectByType<NinjaController>();
                if (ninja != null && ninja.focusMeter != null)
                {
                    ninja.focusMeter.Add(1);
                }
                
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Rune"))
            {
                if (RewardManager.Instance != null)
                {
                    RewardManager.Instance.CollectRune();
                }
                Destroy(other.gameObject);
            }
        }
    }
}
