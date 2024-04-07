using UnityEngine;
using UnityEngine.UI;

public class BestScoreManager : MonoBehaviour
{
    public Text BestScoreText;
    public Text playerNameText; // Reference to the Text component displaying the player name

    private int m_BestScore = 0;

    // Load the best score and player name from player prefs
    private void Start()
    {
        LoadBestScore();
        LoadPlayerName(); // Call the method to load player name
    }

    // Update the best score if the current score is greater
    public void UpdateBestScore(int currentScore)
    {
        if (currentScore > m_BestScore)
        {
            m_BestScore = currentScore;
            BestScoreText.text = $"Best Score: {m_BestScore}";

            // Save the best score
            SaveBestScore();
        }
    }

    // Save the best score to player prefs
    private void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", m_BestScore);
        PlayerPrefs.Save();
    }

    // Load the best score from player prefs
    private void LoadBestScore()
    {
        m_BestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = $"Best Score: {m_BestScore}";
    }

    // Load the player name from player prefs and update the UI
    private void LoadPlayerName()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        playerNameText.text = $"Player: {playerName}";
    }

    // Update the player name in the UI and PlayerPrefs
    public void UpdatePlayerName(string newName)
    {
        playerNameText.text = $"Player: {newName}"; // Update the UI immediately
        PlayerPrefs.SetString("PlayerName", newName); // Save the new name to PlayerPrefs
        PlayerPrefs.Save();
    }
}
