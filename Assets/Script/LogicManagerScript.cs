using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public int flameScore;
    public Text scoreText;
    public Text FlameScoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public bool isGameOver = false;
    public float moveSpeed = 7f;
    private int lastSpeedIncrease = 0;
    public int highScore =0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void Update()
    {
        UpdateHighScore();
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int ScoreatoAdd)
    {
        playerScore += ScoreatoAdd;
        scoreText.text = playerScore.ToString();

        if (isGameOver)
        {
            return; //block further score updates if game is over
        }
    }

    public void AddFlameScore(int flameScoreToAdd)
    {
        flameScore += flameScoreToAdd;
        FlameScoreText.text = flameScore.ToString();

        if (isGameOver)
        {
            return;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public bool gameOver()
    {
        //audioManager.PlaySoundEffect(audioManager.deathClip);
        gameOverScreen.SetActive(true);
        isGameOver = true;
        SaveHighScore();
        return isGameOver;
    }

    public void UpgradeSpeed()
    {
        if (playerScore >= lastSpeedIncrease + 10)
        {
            moveSpeed *= 1.2f;
            lastSpeedIncrease = playerScore;
            Debug.Log("Current Pipe Speed" + moveSpeed);
        }
    }

    private void UpdateHighScore()
    {
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    private void SaveHighScore()
    {
        // Enregistrer le high score quand le jeu est terminé
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        Debug.Log("High Score saved: " + highScore);
    }
}
