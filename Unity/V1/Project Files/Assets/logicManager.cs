using UnityEngine;
using UnityEngine.UI;

public class logicManager : MonoBehaviour
{
    public int player1;
    public int player2;
    public Text score1;
    public Text score2;

    public GameObject scoreLeft;
    public GameObject scoreRight;

    public GameObject winner;
    public GameObject blackScreen;
    public Text winnerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"goals is {OptionScript.goals}");
    }

    // Update is called once per frame
    void checkWin(int player, int score)
    {
        if(score >= OptionScript.goals) {
            Debug.Log($"{player} won");
            scoreLeft.SetActive(false);
            scoreRight.SetActive(false);

            blackScreen.SetActive(true);
            winnerText.text = $"Player {player} Won!";
            winner.SetActive(true);

            StartCoroutine(WaitAndLoadScene());
        }

    }
    public void addScore1() {
        player1++;
        Debug.Log("player 1 scored");
        score1.text = player1.ToString();
        checkWin(1, player1);
    }
    public void addScore2() {
        player2++;
        Debug.Log("player 2 scored");
        score2.text = player2.ToString();
        checkWin(2, player2);
    }

    private System.Collections.IEnumerator WaitAndLoadScene() {
        yield return new WaitForSeconds(1); // Wait 1 second
        CustomSceneManager.titleScene(); // Load the title scene
    }
}
