using UnityEngine;
using UnityEngine.SceneManagement;
public class startGame : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("gameScene");
    }
    public void Quit() {
        Application.Quit();
    }
}
