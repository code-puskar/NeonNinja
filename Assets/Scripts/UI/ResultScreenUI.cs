using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace NeonNinja
{
    public class ResultScreenUI : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public GameManager gameManager;

    void Start()
    {
        if (gameManager == null) gameManager = GameManager.Instance;

        if (gameManager != null)
        {
            gameManager.OnGameOverEvent.AddListener(ShowResultScreen);
        }
        
        gameObject.SetActive(false); // Hidden by default
    }

    private void ShowResultScreen()
    {
        gameObject.SetActive(true);
        if (finalScoreText != null && RewardManager.Instance != null)
        {
            finalScoreText.text = $"Final Score: {RewardManager.Instance.Score}";
        }
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    }
}
