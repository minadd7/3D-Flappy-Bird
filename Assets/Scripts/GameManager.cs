using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreFinalText;
    public TextMeshProUGUI scoreBestText;
    public GameObject gameoverScreen;
    public GameObject pausePanel;
    public static bool isGameActive;

    private int score;
    private int bestScore;
    private bool isPaused;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
    }

    public void GameOver()
    {
        isGameActive = false;
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        gameoverScreen.gameObject.SetActive(true);
        scoreFinalText.text = "" + score;
        scoreBestText.text = "" + bestScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
