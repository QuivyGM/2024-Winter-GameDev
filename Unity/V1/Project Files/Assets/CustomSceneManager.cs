using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{


    public static void gameScene() {
        SceneManager.LoadScene("Game");
    }
    public static void titleScene() {
        SceneManager.LoadScene("Title");
    }

    public static void optionScene() {
        SceneManager.LoadScene("Option");
    }


    public static void Quit() {
        Application.Quit();
    }
}
