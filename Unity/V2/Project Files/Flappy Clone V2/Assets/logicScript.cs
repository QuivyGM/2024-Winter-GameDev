using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal.Internal;

public class LogicScript : MonoBehaviour {
    public int playerScore=0;
    public Text scoreText;
    public Text highScore;
    public GameObject gameOverScreen;

    AudioManager audioM;

    void Start() {
        playerScore = 0;
        highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        audioM = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        audioM.soundEffect(audioM.point);
        checkHighScore();
    }

    void checkHighScore() {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScore.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }
}
