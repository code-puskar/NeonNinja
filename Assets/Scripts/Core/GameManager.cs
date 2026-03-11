using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonNinja
{
    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameState State { get; private set; } = GameState.MainMenu;

        public bool IsPlaying => State == GameState.Playing;

        public UnityEngine.Events.UnityEvent OnGameOverEvent;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartGame()
        {
            ChangeState(GameState.Playing);
            SceneManager.LoadScene("GameScene");
        }

        public void PauseGame()
        {
            if (State == GameState.Playing)
            {
                ChangeState(GameState.Paused);
                Time.timeScale = 0f;
            }
        }

        public void ResumeGame()
        {
            if (State == GameState.Paused)
            {
                ChangeState(GameState.Playing);
                Time.timeScale = 1f;
            }
        }

        public void GameOver()
        {
            ChangeState(GameState.GameOver);
            OnGameOverEvent?.Invoke();
        }

        public void LoadMainMenu()
        {
            ChangeState(GameState.MainMenu);
            SceneManager.LoadScene("MainMenu");
        }

        private void ChangeState(GameState newState)
        {
            State = newState;
        }
    }
}
