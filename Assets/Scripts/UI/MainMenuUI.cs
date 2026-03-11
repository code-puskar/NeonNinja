using UnityEngine;
using UnityEngine.SceneManagement;

namespace NeonNinja
{
    public class MainMenuUI : MonoBehaviour
{
    public void OnPlayClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }
        else
        {
            // Fallback for scene-based design
            SceneManager.LoadScene("GameScene");
        }
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
    }
}
