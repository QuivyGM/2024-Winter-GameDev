using UnityEngine;
using UnityEngine.UI;

public class OptionScript : MonoBehaviour {
    public static int goals = 5;
    public static int ballspeed = 5;

    public Text goalText;
    public Text speedText;

    private void Start() {
        UpdateUI(); // Initialize UI text
        goals = 5;
        ballspeed = 5;
    }

    private void UpdateUI() {
        goalText.text = $"Goals to Win: {goals}";
        speedText.text = $"Ball Speed: {ballspeed}";
    }

    public void IncreaseGoal() {
        goals = Mathf.Min(goals + 1, 10);
        Debug.Log($"Goals increased to: {goals}");
        UpdateUI();
    }

    public void DecreaseGoal() {
        goals = Mathf.Max(1, goals - 1); // Prevent negative goals
        Debug.Log($"Goals decreased to: {goals}");
        UpdateUI();
    }

    public void IncreaseSpeed() {
        ballspeed++;
        Debug.Log($"Ball speed increased to: {ballspeed}");
        UpdateUI();
    }

    public void DecreaseSpeed() {
        ballspeed = Mathf.Max(1, ballspeed-1); // Prevent negative speed
        Debug.Log($"Ball speed decreased to: {ballspeed}");
        UpdateUI();
    }
}
