using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private int currentScore = 0;
    private int bestScore = 0;
    public int BestScore { get { return bestScore; } }

    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FlappyPlane")
        {
            uiManager = FindObjectOfType<UIManager>();
            currentScore = 0;
            if (uiManager != null)
            {
                uiManager.UpdateScore(currentScore);
            }
        }
    }

    public void StartFlappyPlaneGame()
    {
        SceneManager.LoadScene("FlappyPlane");
    }

    public void GameOver()
    {
        Debug.Log("Game Over");

        if (currentScore > bestScore)
        {
            bestScore = currentScore;
        }

        if (uiManager != null)
        {
            uiManager.SetRestart();
            uiManager.SetBack();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " + currentScore);
        if (uiManager != null)
        {
            uiManager.UpdateScore(currentScore);
        }
    }
}